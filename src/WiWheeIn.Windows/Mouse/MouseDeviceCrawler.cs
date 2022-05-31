using System.Management;
using WiWheeIn.BusinessLogic.Devices;
using WiWheeIn.BusinessLogic.Mouse;

namespace WiWheeIn.Windows.Mouse;

public class MouseDeviceCrawler : IMouseDeviceCrawler
{
    private const string PnpMouseClassName = "Mouse";
    private const string PnpClass = "PNPClass";

    // property names listed here: 
    // https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-pnpentity
    private const string DeviceID = "DeviceID";
    private const string Caption = "Caption";
    private const string Manufacturer = "Manufacturer";
    private readonly IDevicePathBuilder _devicePathBuilder;

    public MouseDeviceCrawler(IDevicePathBuilder devicePathBuilder)
    {
        _devicePathBuilder = devicePathBuilder;
    }

    public Task<List<DeviceInfo>> GetMouseDevicesAsync()
    {
        var tcs = new TaskCompletionSource<List<DeviceInfo>>();

        _ = Task.Run(() => GetMouseDevices(tcs));

        return tcs.Task;
    }

    private void GetMouseDevices(TaskCompletionSource<List<DeviceInfo>> tcs)
    {
        var devices = new List<DeviceInfo>();

        var searcher = new ManagementObjectSearcher("Select * from Win32_PnPEntity");
        var searchResult = searcher.Get();
        foreach (var entry in searchResult)
        {
            var pnpClass = entry.GetPropertyValue(PnpClass) as string;
            if (pnpClass != PnpMouseClassName)
            {
                continue;
            }

            var props = new Dictionary<string, string>();
            foreach (var property in entry.Properties)
            {
                if (property.Value is string[] array)
                {
                    for (var i = 1; i <= array.Length; i++)
                    {
                        props[$"{property.Name}[{i}]"] = array[i - 1];
                    }

                    continue;
                }

                props[property.Name] = property.Value?.ToString() ?? string.Empty;
            }

            DeviceInfo deviceInfo;
            deviceInfo = new DeviceInfo
            {
                DeviceId = GetPropertyValue(entry, DeviceID),
                Name = GetPropertyValue(entry, Caption),
                Manufacturer = GetPropertyValue(entry, Manufacturer),
                AllInfos = props
            };

            deviceInfo.DevicePath = _devicePathBuilder.GetDevicePath(deviceInfo);

            if (deviceInfo is null)
            {
                continue;
            }

            devices.Add(deviceInfo);
        }

        tcs.SetResult(devices);
    }

    private static string GetPropertyValue(ManagementBaseObject entry, string property)
    {
        return entry.GetPropertyValue(property) as string ?? string.Empty;
    }
}
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.Immutable;

namespace WiWheeIn.BusinessLogic.Devices;

public class DeviceInfo : ObservableObject
{
    private string _deviceId = string.Empty;
    private string _manufacturer = string.Empty;
    private string _name = string.Empty;
    private IDictionary<string, string> _allInfos = ImmutableDictionary<string, string>.Empty;
    private string _devicePath = string.Empty;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Manufacturer
    {
        get => _manufacturer;
        set => SetProperty(ref _manufacturer, value);
    }

    public string DeviceId
    {
        get => _deviceId;
        set => SetProperty(ref _deviceId, value);
    }

    public string DevicePath
    {
        get { return _devicePath; }
        set { SetProperty(ref _devicePath, value); }
    }

    public IDictionary<string, string> AllInfos
    {
        get => _allInfos;
        set => SetProperty(ref _allInfos, value);
    }

    public override string ToString()
    {
        return $"{Manufacturer} - {Name}";
    }
}

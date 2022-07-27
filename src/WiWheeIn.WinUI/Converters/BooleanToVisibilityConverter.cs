using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;
using System.Globalization;

namespace WiWheeIn.WinUI.Converters
{
    internal class BooleanToVisibilityConverter : IValueConverter
    {
        public bool IsInverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var boolean = value as bool?;
            if (boolean is null)
            {
                return DependencyProperty.UnsetValue;
            }

            if (IsInverted)
            {
                return boolean.Value ? Visibility.Collapsed : Visibility.Visible;
            }

            return boolean.Value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

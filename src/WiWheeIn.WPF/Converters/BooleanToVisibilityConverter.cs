using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WiWheeIn.WPF.Converters
{
    internal class BooleanToVisibilityConverter : IValueConverter
    {
        public bool IsInverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

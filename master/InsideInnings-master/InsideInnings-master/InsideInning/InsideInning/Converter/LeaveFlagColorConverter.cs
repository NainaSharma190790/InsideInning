using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InsideInning
{
    public class LeaveFlagColorConverter
    {
        public static IValueConverter OneWay<TFrom, TTo>(Func<TFrom, TTo> converter)
        {
            return new ValueConverterImpl<TFrom, TTo>(converter, null);
        }

        public static IValueConverter TwoWay<TFrom, TTo>(Func<TFrom, TTo> converter, Func<TTo, TFrom> backConverter)
        {
            return new ValueConverterImpl<TFrom, TTo>(converter, backConverter);
        }

        private class ValueConverterImpl<TSource, TDestination> : IValueConverter
        {
            private Func<TSource, TDestination> _converter;
            private Func<TDestination, TSource> _backConverter;

            public ValueConverterImpl(Func<TSource, TDestination> converter, Func<TDestination, TSource> backConverter)
            {
                _converter = converter;
                _backConverter = backConverter;
            }

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return _converter((TSource)value);
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (_backConverter == null)
                    throw new NotImplementedException();

                return _backConverter((TDestination)value);
            }
        }
    }
}

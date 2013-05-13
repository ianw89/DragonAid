using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using DragonAid.Lib.Data.Model;
#if INCLUDE_AZURE_BINDINGS
using Windows.UI.Xaml.Data;
#endif

namespace DragonAid.Lib.Data
{
#if INCLUDE_AZURE_BINDINGS
    public class DetermineChanceOfSuccessConverter : IValueConverter
#else
    public class DetermineChanceOfSuccessConverter
#endif
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Contract.Assert(targetType == "".GetType());
            Contract.Requires(value != null && value is Func<Character, int>);
            Contract.Requires(parameter != null && parameter is Character);

            var determineChanceOfSuccess = value as Func<Character, int>;
            var character = parameter as Character;

            int successChance = determineChanceOfSuccess(character);

            return string.Format(new CultureInfo(language), "{0}", successChance);
        }

        // No need to implement converting back on a one-way binding 
        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

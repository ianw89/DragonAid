using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using DragonAidLib.Data.Model;
using Windows.UI.Xaml.Data;

namespace DragonAidLib.Data
{
    public class DetermineChanceOfSuccessConverter : IValueConverter
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

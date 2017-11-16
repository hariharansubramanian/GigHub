using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.Validators
{
    public class FutureDateValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, out dateTime);
            return (isValid && dateTime > DateTime.Now);
        }
    }
}
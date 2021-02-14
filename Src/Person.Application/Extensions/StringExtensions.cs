using Person.Domain;
using Person.Domain.ValueObjects;
using PhoneNumbers;
using System.Linq;

namespace Person.Application.Extensions
{
    public static class StringExtensions
    {
        private const int COUNTRY_CODE_POSITION = 0;
        private const int AREA_CODE_POSITION = 1;
        private const int PHONE_NUMBER_POSITION = 2;
        public static Phone Parse(this string number)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var parsedNumber = phoneNumberUtil.Parse(number, "BR");
            var internationalNumber = (phoneNumberUtil.Format(parsedNumber, PhoneNumberFormat.INTERNATIONAL)).Split(' ');

            return new(internationalNumber[COUNTRY_CODE_POSITION],
                internationalNumber[AREA_CODE_POSITION],
                internationalNumber[PHONE_NUMBER_POSITION].RemoveNonNumbers());
        }
        public static string RemoveNonNumbers(this string text) => new(text.Where(c => char.IsDigit(c)).ToArray());
    }
}

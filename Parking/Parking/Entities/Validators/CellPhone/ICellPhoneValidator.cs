using static Entities.Country;

namespace Entities.Validation
{
    public interface ICellPhoneValidator 
    {
        Notification ValidateCellPhone(string cellPhoneToValidate);
        CountriesInSystem CellPhoneValidatorCountry { get; set; }
        bool PhoneNumberCorrectFormat(string cellPhoneNumberToValidate);
    }
}

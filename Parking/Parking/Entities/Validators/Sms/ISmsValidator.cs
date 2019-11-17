using static Entities.Country;

namespace Entities.Validation
{
    public interface ISmsValidator
    {
        CountriesInSystem SmsValidatorCountry { get; set; }
        Notification ValidateSms(Sms smsToValidate);
        bool IsCorrectFormat(Sms smsToValidate);
        Sms GetInitializedSms(string smsToInitialize);
    }
}

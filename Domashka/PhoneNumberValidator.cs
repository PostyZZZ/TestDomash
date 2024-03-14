public class PhoneNumberValidator
{
    public bool ValidatePhoneNumber(string phoneNumber)
    {
        // Поддерживаемый шаблон: 8-9XX-XXX-XX-XX
        string pattern = @"^8-[9]\d{2}-\d{3}-\d{2}-\d{2}$";

        // Используем регулярное выражение для проверки соответствия
        return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, pattern);
    }
}

using System;
using Xunit;

public class EmailValidatorTests
{
    [Theory]
    [InlineData("test@example.com", true)]         // Валидный адрес
    [InlineData("invalid-email", false)]           // Невалидный адрес (отсутствует @)
    [InlineData("test@.com", false)]               // Невалидный адрес (отсутствует домен)
    [InlineData("test@domain", false)]             // Невалидный адрес (отсутствует домен верхнего уровня)
    [InlineData("test@.com.", false)]              // Невалидный адрес (точка в конце домена)
    [InlineData("test@.com.123", false)]           // Невалидный адрес (цифры в домене)
    public void IsValidEmail_WithVariousEmails_ReturnsExpectedResult(string email, bool expectedResult)
    {
        // Arrange
        var emailValidator = new EmailValidator(); // Замените на ваш класс для проверки электронной почты

        // Act
        var isValidEmail = emailValidator.IsValidEmail(email);

        // Assert
        Assert.Equal(expectedResult, isValidEmail);
    }
}

// Пример простого класса для проверки электронной почты
public class EmailValidator
{
    public bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}

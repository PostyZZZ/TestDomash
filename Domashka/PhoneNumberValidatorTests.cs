using Xunit;

public class PhoneNumberValidatorTests
{
    [Theory]
    [InlineData("8-912-345-67-89")]
    [InlineData("9-987-654-32-10")]
    [InlineData("8-999-876-54-32")]
    public void ValidPhoneNumber_ReturnsTrue(string phoneNumber)
    {
        // Arrange
        var validator = new PhoneNumberValidator();

        // Act
        bool isValid = validator.ValidatePhoneNumber(phoneNumber);

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("123-456-7890")]
    [InlineData("8-1234-567-890")]
    [InlineData("8-123-45-67890")]
    [InlineData("8-912-345-67-8a")]
    [InlineData("invalid-format")]
    public void InvalidPhoneNumber_ReturnsFalse(string phoneNumber)
    {
        // Arrange
        var validator = new PhoneNumberValidator();

        // Act
        bool isValid = validator.ValidatePhoneNumber(phoneNumber);

        // Assert
        Assert.False(isValid);
    }
}

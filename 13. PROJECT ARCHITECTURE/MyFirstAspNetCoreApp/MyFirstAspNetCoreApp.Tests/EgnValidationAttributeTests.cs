using MyFirstAspNetCoreApp.ValidationAttributes;
using System;
using Xunit;

namespace MyFirstAspNetCoreApp.Tests
{
    public class EgnValidationAttributeTests
    {
        [Fact]
        public void Egn1234567890ShouldBeValid()
        {
            // Arrange
            var validationAttribute = new EgnValidationAttribute();

            // Act
            var isValid = validationAttribute.IsValid("1234567890");

            // Assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("1234567899")]
        [InlineData("aadad")]
        [InlineData("asdfghjksd")]
        [InlineData("123456789")]
        [InlineData("\0")]
        [InlineData("        ")]
        public void EgnShouldBeInvalid(string egn)
        {
            var attribute = new EgnValidationAttribute();

            var result = attribute.IsValid(egn);

            Assert.False(result);
        }
    }
}

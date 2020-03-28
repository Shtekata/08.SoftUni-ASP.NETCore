using MyFirstAspNetCoreApp.Models;
using System;
using System.Linq;
using Xunit;

namespace MyFirstAspNetCoreApp.Tests
{
    public class TestInputModelTests
    {
        [Fact]
        public void YearAndEgnShouldMatch()
        {
            var viewModel = new TestInputModel
            {
                DateOfBirth = new DateTime(1912, 1, 1),
                Egn = "1234567890",
            };

            var errors = viewModel.Validate(null).Count();

            Assert.Equal(0, errors);
        }

        [Fact]
        public void YearAndEgnShouldReturnErrorWhenDontMatch()
        {
            var viewModel = new TestInputModel
            {
                DateOfBirth = new DateTime(1912, 1, 1),
                Egn = "1134567890",
            };

            var errors = viewModel.Validate(null).Count();

            Assert.Equal(1, errors);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPP.Core.Services;

namespace SPP.Tests
{
    [TestClass]
    public class AuthenticationTests
    {
        private AuthenticationService _authService;

        [TestInitialize]
        public void Setup()
        {
            _authService = new AuthenticationService();
        }

        [TestMethod]
        public void Test_ValidUser_Login()
        {
            // Arrange
            var username = "validUser";
            var password = "validPassword";

            // Act
            var result = _authService.Login(username, password);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_InvalidUser_Login()
        {
            // Arrange
            var username = "invalidUser";
            var password = "invalidPassword";

            // Act
            var result = _authService.Login(username, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_EmptyUsername_Login()
        {
            // Arrange
            var username = "";
            var password = "somePassword";

            // Act
            var result = _authService.Login(username, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_EmptyPassword_Login()
        {
            // Arrange
            var username = "someUser";
            var password = "";

            // Act
            var result = _authService.Login(username, password);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
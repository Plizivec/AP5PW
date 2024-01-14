using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Project.Web.Areas.Security.Controllers;
using Project.Web.Controllers;
using Project.Tests.Account;
using Project.Application.Abstraction;
using Project.Application.ViewModels;
using UTB.Eshop.Tests.Helpers;

namespace Project.Tests.Account
{
    public class AccountControllerLoginTests
    {
        [Fact]
        public async Task Login_ValidSuccess()
        {
            // Arrange
            var mockISecurityApplicationService = new Mock<IAccountService>();
            mockISecurityApplicationService.Setup(security => security.Login(It.IsAny<LoginViewModel>()))
                                           .ReturnsAsync(true);

            var mockRecipeAdminService = new Mock<IRecipeAdminService>();
            var mockMenuService = new Mock<IMenuService>();
            var mockTipService = new Mock<ITipService>();

            AccountController controller = new AccountController(
                mockISecurityApplicationService.Object,
                mockRecipeAdminService.Object,
                mockMenuService.Object,
                mockTipService.Object
            );

            //Act
            IActionResult iActionResult = await controller.Login(new LoginViewModel());

            // Assert
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(nameof(HomeController.Index), redirect.ActionName);
            Assert.Matches(nameof(HomeController).Replace(nameof(Controller), String.Empty), redirect.ControllerName);
            Assert.Matches(String.Empty, redirect.RouteValues.Single((pair) => pair.Key == "area").Value.ToString());
        }

        [Fact]
        public async Task Login_InvalidFailure()
        {
            // Arrange
            var mockISecurityApplicationService = new Mock<IAccountService>();
            mockISecurityApplicationService.Setup(security => security.Login(It.IsAny<LoginViewModel>()))
                                           .ReturnsAsync(false);

            var mockRecipeAdminService = new Mock<IRecipeAdminService>();
            var mockMenuService = new Mock<IMenuService>();
            var mockTipService = new Mock<ITipService>();

            AccountController controller = new AccountController(
                mockISecurityApplicationService.Object,
                mockRecipeAdminService.Object,
                mockMenuService.Object,
                mockTipService.Object
            );

            //Act
            IActionResult iActionResult = await controller.Login(new LoginViewModel());

            // Assert
            ViewResult viewResult = Assert.IsType<ViewResult>(iActionResult);

            Assert.NotNull(viewResult.Model);
            LoginViewModel? logingVM = viewResult.Model as LoginViewModel;
            Assert.NotNull(logingVM);
            Assert.NotNull(logingVM.Username);
            Assert.Matches("a", logingVM.Username); // Update this line according to your test data
            Assert.NotNull(logingVM.Password);
            Assert.Matches("a", logingVM.Password); // Update this line according to your test data
        }


        [Fact]
        public async Task LoginValidation_InvalidFailure()
        {
            // Arrange
            var mockISecurityApplicationService = new Mock<IAccountService>();
            mockISecurityApplicationService.Setup(security => security.Login(It.IsAny<LoginViewModel>()))
                                           .ReturnsAsync(true);

            var mockRecipeAdminService = new Mock<IRecipeAdminService>();
            var mockMenuService = new Mock<IMenuService>();
            var mockTipService = new Mock<ITipService>();

            LoginViewModel loginViewModel = new LoginViewModel()
            {
                Username = "a",
                Password = ""
            };

            // Provide mocks for other services
            AccountController controller = new AccountController(
                mockISecurityApplicationService.Object,
                mockRecipeAdminService.Object,
                mockMenuService.Object,
                mockTipService.Object);

            // Set ObjectValidator to false
            controller.ObjectValidator = new ObjectValidator(false);

            // Act
            controller.TryValidateModel(loginViewModel);
            IActionResult iActionResult = await controller.Login(loginViewModel);

            // Reset ObjectValidator to null
            controller.ObjectValidator = null;

            // Assert
            ViewResult viewResult = Assert.IsType<ViewResult>(iActionResult);

            Assert.NotNull(viewResult.Model);
            LoginViewModel? logingVM = viewResult.Model as LoginViewModel;
            Assert.NotNull(logingVM);
            Assert.NotNull(logingVM.Username);
            Assert.Matches(loginViewModel.Username, logingVM.Username);
            Assert.NotNull(logingVM.Password);
            Assert.Matches(loginViewModel.Password, logingVM.Password);
        }
    }
}

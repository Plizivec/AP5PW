using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Project.Application.Abstraction;
using Project.Domain.Entities;
using Project.Web.Controllers;
using Xunit;

namespace Project.Tests.Controllers
{
    public class RecipeControllerTests
    {
        [Fact]
        public void Search_ReturnsViewWithSearchResults()
        {
            // Arrange
            string searchTerm = "Chicken";
            int? categoryId = 1;
            var expectedSearchResults = new List<Recipe>
            {
                new Recipe { Id = 1, Name = "Chicken Soup" },
                new Recipe { Id = 2, Name = "Grilled Chicken" }
            };

            var recipeAdminServiceMock = new Mock<IRecipeAdminService>();
            recipeAdminServiceMock.Setup(service => service.SearchRecipes(searchTerm, categoryId))
                .Returns(expectedSearchResults);

            var homeServiceMock = new Mock<IHomeService>();
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

            var controller = new RecipeController(recipeAdminServiceMock.Object, homeServiceMock.Object, httpContextAccessorMock.Object);

            // Act
            IActionResult result = controller.Search(searchTerm, categoryId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<List<Recipe>>(viewResult.Model);

            Assert.Equal(expectedSearchResults.Count, model.Count);

            Assert.Equal(expectedSearchResults[0].Name, model[0].Name);
        }

        [Fact]
        public void Details_ReturnsViewWithRecipeDetails()
        {
            // Arrange
            int recipeId = 1;
            var expectedRecipe = new Recipe { Id = recipeId, Name = "Test Recipe" };

            var recipeAdminServiceMock = new Mock<IRecipeAdminService>();
            recipeAdminServiceMock.Setup(service => service.Select())
                .Returns(new[] { expectedRecipe });

            var homeServiceMock = new Mock<IHomeService>();
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

            var controller = new RecipeController(recipeAdminServiceMock.Object, homeServiceMock.Object, httpContextAccessorMock.Object);

            // Act
            IActionResult result = controller.Details(recipeId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Recipe>(viewResult.Model);


            Assert.Equal(expectedRecipe.Id, model.Id);
            Assert.Equal(expectedRecipe.Name, model.Name);
        }
    }
}
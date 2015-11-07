using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BlondsCooking.Controllers;
using BlondsCooking.Models.Structure;
using BlondsCooking.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlondsCooking.Tests.Controllers
{
    [TestClass]
    public class CategoryControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            CategoryController controller = new CategoryController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReturnsSelectedRecipe()
        {
            var db = new FakeBlondsCookingContext();
            db.AddSet(FakeData.Categories);
            db.AddSet(FakeData.Recipes);
            CategoryController controller = new CategoryController();

            ViewResult result = controller.Recipe(1) as ViewResult;
            Recipe model = result.Model as Recipe;
            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void ReturnsErrorPageWhenCannotFindSelectedRecipe()
        {
            var db = new FakeBlondsCookingContext();
            db.AddSet(FakeData.Categories);
            db.AddSet(FakeData.Recipes);
            CategoryController controller = new CategoryController();

            ViewResult result = controller.Recipe(-1) as ViewResult;

            Assert.AreEqual("Error", result.ViewName);

        }
    }
}

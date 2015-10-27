using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlondsCooking;
using BlondsCooking.Controllers;
using BlondsCooking.Models.Structure;
using BlondsCooking.Tests.Fakes;

namespace BlondsCooking.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Category()
        {
            var db = new FakeBlondsCookingContext();
            db.AddSet(FakeData.Categories);
            db.AddSet(FakeData.Recipes);
            HomeController controller = new HomeController(db);

            ViewResult result = controller.Category(1) as ViewResult;
            IEnumerable<Recipe> model = result.Model as IEnumerable<Recipe>;
            Assert.AreEqual(9, model.Count());

        }
    }
}

﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TwitchForum;
using TwitchForum.Controllers;

namespace TwitchForum.Tests.Controllers
{
    [TestClass]
    public class MainControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // // Arrange
            // MainController controller = new MainController();

            // //Act
            //ViewResult result = controller.Index(1) as ViewResult;

            // //Assert
            // Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            //HomeController controller = new HomeController();

            //// Act
            //ViewResult result = controller.About() as ViewResult;

            //// Assert
            //Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            ////HomeController controller = new HomeController();

            ////// Act
            ////ViewResult result = controller.Contact() as ViewResult;

            ////// Assert
            ////Assert.IsNotNull(result);
        }
    }
}
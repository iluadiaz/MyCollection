using __460A1;
using __460A1.Controllers;
using __460A1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace __460A1.Tests.Controllers
{
    [TestClass]
    public class UpdateControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            UpdateController controller = new UpdateController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void UpdateView()
        {


            // Arrange
            UpdateController controller = new UpdateController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UpdateController()
        {

            Update tester = new Update();

            tester.frontChainSize = "12,15,78";
            tester.rearCogSize = "82,11,23";
            // Arrange
            UpdateController controller = new UpdateController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

            Assert.IsNotNull(tester.frontChainSize);

        }

        }
    }


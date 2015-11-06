using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OliApi.Controllers;

namespace OliApi.Tests.Controllers
{
    [TestClass]
    public class PostItControllerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
             var controller = new PostItsController();
            var guid = new Guid("e8c4809c-851b-4819-a727-0b987b4fb45f");
            var postIt = new PostIt
            { 
                PostItGuid = new Guid("e8c4809c-851b-4819-a727-0b987b4fb45f"),
                Titel = "XXX",
                Datum = new DateTime(2015, 11, 06, 0, 0, 0),
                Hits = 12,
                URL = "http://localhost",
                PostItZust = 1,
                Typ = "txt",
                PostIt1 = "XXX"
            };

            // Act
            PostIt result = controller.GetPostIt(guid);

            // Assert
            if (!postIt.Equals(result))
            {
                throw new AssertFailedException();
            }
            Assert.AreEqual(postIt.PostItGuid, result.PostItGuid);
            Assert.AreEqual(postIt.PostIt1, result.PostIt1);
            Assert.AreEqual(postIt.Typ, result.Typ);
            Assert.AreEqual(postIt.Datei, result.Datei);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestCase(2, new string[] { "Nelly Furtado", "The Lost World", "3/12/2016" })]
        public void DetailTest(int id, string[] expected)
        {
            var controller = new HomeController();
            ActionResult actual = controller.Detail();
            Assert.AreEqual(expected, actual);
        }

        //[TestCase(2, new string[] { "Nelly Furtado", "The Lost World", "3/12/2016" })]
        //public void TestMovieMovie(int id, string[] expected)
        //{
        //    var controller = new HomeController();
        //    var result = controller.Detail() as ViewResult;
        //    Assert.AreEqual(expected, result.ViewName);

        //}

        //public void TestDeleteMovie()
        //{
        //    var controller = new HomeController();
        //    var result = controller.DeleteMovie(2) as ViewResult;
        //    Assert.AreEqual(null, result.ViewName);

        //}

        //[TestCase(new int[] { 1, 2, 1 }, true)]
        //public void CreateMovieTest()
        //{
        //    var controller = new HomeController();
        //    bool actual = controller.CreateMovie();
        //    Assert.AreEqual(expected, actual);
        //}
    }
}

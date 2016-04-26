using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NUnit.Framework;
using DVDLibrary.Services;
using DVDLibrary.Models;
using DVDLibrary.Repositiories;

namespace DVDLibrary.Controllers
{
    [TestFixture]
    public class ControllerTest
    {
        HomeController h = new HomeController(new FakeService());

        //public void TestAddView()
        //{
        //    HomeController t = new HomeController();
        //    ViewResult r = t.Add() as ViewResult;
        //    Assert.AreEqual("Index", r.ViewName);
        //}

        [Test]
        public void TestAddMovie()
        {
            int before = FakeService.MoviesMaster.Count;
            Movie movie = new Movie()
            {
                Title = "Blade 2",
                Director = "Guillermo del Toro",
            };
            h.CreateMovie(movie);
            int after = FakeService.MoviesMaster.Count;

            Assert.AreEqual(after, before + 1);
        }

        [Test]
        public void DeleteMovie()
        {
            int before = FakeService.MoviesMaster.Count;
            h.DeleteMovie(2);
            int after = FakeService.MoviesMaster.Count;

            Assert.AreEqual(after, before - 1);
        }
        
    }

    [TestFixture]
    public class ServiceTests
    {
        LogicService l = new LogicService(new FakeRepository());

        //[Test]
        //public void GetBorrowMovie()
        //{
        //    int borrowmovieid = FakeService.BorrowsMaster.
        //    l.Detail();
        //    Assert.AreEqual()
        //}
        



    }

}
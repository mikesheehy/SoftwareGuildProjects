using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlooringProgram.Models;
using FlooringProgram.BLL;

namespace FlooringSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display()
        {
            ViewBag.Message = "Your display page.";

            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Message = "Your add page.";

            return View();
        }

        public ActionResult Edit()
        {
            ViewBag.Message = "Your edit page.";

            return View();
        }
        public ActionResult Delete()
        {
            ViewBag.Message = "Your delete page.";

            return View();
        }
        public ActionResult AddOrder()
        {
            var o = new Order();
            string formattedDate = DateTime.Now.ToString("MM-dd-yyyy");
            o.OrderDate = formattedDate;
            o.CustomerName = Request.Form["Name"];
            o.State = Request.Form["State"];
            o.ProductType = Request.Form["ProductType"];
            string initArea = Request.Form["Area"];
            decimal initialArea;
            bool res = decimal.TryParse(initArea, out initialArea);
            if (res == false)
            {
                Console.WriteLine("Please enter a valid numeric value for area.");
            }
            decimal area = initialArea;

            o.Area = area;
            o.CostPerSquareFoot = o.CostPerSquareFoot;
            o.LaborCostPerSquareFoot = o.LaborCostPerSquareFoot;
            o.MaterialCost = (o.CostPerSquareFoot) * (area);
            o.LaborCost = (o.LaborCostPerSquareFoot) * (area);
            decimal totalnotax = o.MaterialCost + o.LaborCost;

            o.TaxRate = (o.TaxRate) / 100;
            decimal totaltax = totalnotax * o.TaxRate;
            o.Tax = totaltax;
            decimal total = totalnotax + o.Tax;
            o.Total = total;

            var database = new OrderManager ();
            database.CreateFileForOrder(o);
            return RedirectToAction("Index");
        }


    }
}
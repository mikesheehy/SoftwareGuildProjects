using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringProgram.BLL;
using FlooringProgram.Data;

namespace FlooringProgram.Tests
{
    [TestFixture]
    public class TestManager
    {

        [Test]
        public void TestZero()
        {
            Assert.AreEqual(0, 0);
        }


        [Test]
        public void NumberGenerator()
        {
            var manager = new OrderManager();
            var orderlist = manager.GetOrder("03-18-2016", 0);
            var repo = new MockOrderRepository();
            var ordernumber = repo.GenerateOrderNumber(orderlist.Data);
            Assert.AreEqual(orderlist.Data.OrderNumber, ordernumber - 1);
        }

        [Test]
        public void GettingAnOrder()
        {
            var manager = new OrderManager();
            var response = manager.GetOrder("03-18-2016", 0);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(0, response.Data.OrderNumber);
            Assert.AreEqual("Kanye West", response.Data.CustomerName);
        }

        [Test]
        public void DeletingOrder()
        {
            var manager = new OrderManager();
            var orderlist = manager.GetOrder("03-18-2016", 0);
            manager.DeleteFromList("03-18-2016", 0);
            //var result = from o in orderlist select new { o.CustomerName, count = o.Orders.Count() };

            Assert.IsNull(orderlist.Data);
        }


        [Test]
        public void editOrder()
        {
            var manager = new OrderManager();
            var OrderList = manager.GetOrder("03-18-2016", 0);
            OrderList.Data.CustomerName = "Jay Z";

            var result = manager.GetOrder("03-18-2016", 0);

            Assert.AreEqual("Jay Z", result.Data.CustomerName);
        }

        

    }
}

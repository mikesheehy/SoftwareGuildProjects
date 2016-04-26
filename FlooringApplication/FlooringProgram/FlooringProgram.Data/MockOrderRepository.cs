using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class MockOrderRepository : IOrderRepository
    {

        private static List<Order> _orders;

        public MockOrderRepository()
        {
            _orders = new List<Order>();
        }

        public void DeleteFile(string orderDate)
        {
            _orders.Clear();
        }

        public Order DisplayLoadOrder(string orderDate, int orderNumber)
        {
            throw new NotImplementedException();
        }

        public int GenerateOrderNumber(Order neworder)
        {
            return _orders.Count;
        }

        public List<Order> GetAllDisplayOrders(string orderDate)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllExistingOrders(Order neworder)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllNonDeletedOrders(string orderDate, int orderNumber)
        {

            _orders.Add(new Order()
            {
                OrderDate = "03-18-2016",
                OrderNumber = 0,
                State = "KY",
                ProductType = "Wood",
                CustomerName = "Kanye West",
                Area = 100,
                CostPerSquareFoot = 5.00M,
                LaborCostPerSquareFoot = 6.00M,
                MaterialCost = 500,
                LaborCost = 600,
                TaxRate = 0.0625M,
                Total = 1168.75M
            });
            return _orders;

        }

        public List<Order> GetAllOrders(string orderDate)
        {
            _orders.Add(new Order() {
                OrderDate = "03-18-2016",
                OrderNumber = 0,
                State = "KY",
                ProductType = "Wood",
                CustomerName = "Kanye West",
                Area = 100,
                CostPerSquareFoot = 5.00M,
                LaborCostPerSquareFoot = 6.00M,
                MaterialCost = 500,
                LaborCost = 600,
                TaxRate = 0.0625M,
                Total = 1168.75M
            });
            return _orders;
        }

        public string GetFilePath(string orderDate)
        {
            throw new NotImplementedException();
        }    

        public Order LoadOrder(string orderDate, int orderNumber)
        {
            List<Order> orders = GetAllOrders(orderDate);
            return orders.FirstOrDefault(o => o.OrderDate == orderDate);

        }

        public void NewOrderFile(Order neworder)
        {
            throw new NotImplementedException();
        }

        public void OverwriteExistingFile(List<Order> orders, Order neworder)
        {
            throw new NotImplementedException();
        }

        public void OverwriteFile(List<Order> _orders, string orderDate)
        {
            var UpdatedOrder = new Order();

            var existingOrder = MockOrderRepository._orders.First(o => o.OrderNumber == UpdatedOrder.OrderNumber);
            existingOrder.CustomerName = UpdatedOrder.CustomerName;
            existingOrder.State = UpdatedOrder.State;
            existingOrder.ProductType = UpdatedOrder.ProductType;
            existingOrder.Area = UpdatedOrder.Area;
            existingOrder.MaterialCost = UpdatedOrder.CostPerSquareFoot * UpdatedOrder.Area;
            existingOrder.CostPerSquareFoot = UpdatedOrder.CostPerSquareFoot;
            existingOrder.LaborCostPerSquareFoot = UpdatedOrder.LaborCostPerSquareFoot;
            existingOrder.LaborCost = UpdatedOrder.LaborCostPerSquareFoot * UpdatedOrder.Area;
            existingOrder.TaxRate = UpdatedOrder.TaxRate;
            existingOrder.Tax = (UpdatedOrder.MaterialCost + UpdatedOrder.LaborCost) * (UpdatedOrder.TaxRate / 100);
            existingOrder.Total = existingOrder.Tax + existingOrder.LaborCost + existingOrder.MaterialCost;
        }

        public void UpdateOrder(Order orderToUpdate, string orderDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(List<Order> _orders, Order UpdatedOrder)
        {

            var existingOrder = _orders.First(o => o.OrderNumber == UpdatedOrder.OrderNumber);
            existingOrder.CustomerName = UpdatedOrder.CustomerName;
            existingOrder.State = UpdatedOrder.State;
            existingOrder.ProductType = UpdatedOrder.ProductType;
            existingOrder.Area = UpdatedOrder.Area;
            existingOrder.MaterialCost = UpdatedOrder.CostPerSquareFoot * UpdatedOrder.Area;
            existingOrder.CostPerSquareFoot = UpdatedOrder.CostPerSquareFoot;
            existingOrder.LaborCostPerSquareFoot = UpdatedOrder.LaborCostPerSquareFoot;
            existingOrder.LaborCost = UpdatedOrder.LaborCostPerSquareFoot * UpdatedOrder.Area;
            existingOrder.TaxRate = UpdatedOrder.TaxRate;
            existingOrder.Tax = (UpdatedOrder.MaterialCost + UpdatedOrder.LaborCost) * (UpdatedOrder.TaxRate / 100);
            existingOrder.Total = existingOrder.Tax + existingOrder.LaborCost + existingOrder.MaterialCost;

        }
    }
}

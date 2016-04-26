using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using System.IO;

namespace FlooringProgram.Data
{
    public class OrderRepository : IOrderRepository
    {

        //private const string FilePath = @"DataFiles/Order_" + orderDate + ".txt";

        //public OrderRepository(DateTime orderDate)
        //{
        //    FilePath = GetFilePath(orderDate);
        // }

        //new OrderRepository(somedatehere);

        public string GetFilePath(string orderDate)
        {
            return @"DataFiles/Order_" + orderDate + ".txt";
        }


        public List<Order> GetAllOrders(string orderDate)

        {
            //string FilePath = @"DataFiles/Order_" + orderDate + ".txt";
            string FilePath = GetFilePath(orderDate);

            List<Order> orders = new List<Order>();
            //Need when doing mock repository
            //orders.Add(new Order() { OrderNumber = 1 });

            //string custompath = @"DataFiles/" + CustomerName + ".txt";

            var reader = File.ReadAllLines(FilePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var order = new Order();


                order.OrderDate = columns[0];
                order.OrderNumber = int.Parse(columns[1]);
                order.CustomerName = columns[2];
                order.State = columns[3];
                order.TaxRate = decimal.Parse(columns[4]);
                order.Area = decimal.Parse(columns[5]);
                order.ProductType = columns[6];
                order.CostPerSquareFoot = decimal.Parse(columns[7]);
                order.LaborCostPerSquareFoot = decimal.Parse(columns[8]);
                order.MaterialCost = decimal.Parse(columns[9]);
                order.LaborCost = decimal.Parse(columns[10]);
                order.Tax = decimal.Parse(columns[11]);
                order.Total = decimal.Parse(columns[12]);

                orders.Add(order);
            }

            return orders;
        }


        public Order LoadOrder(string orderDate, int orderNumber)
        {
                    List<Order> orders = GetAllOrders(orderDate);
                    return orders.FirstOrDefault(o => o.OrderDate == orderDate);
        }

        public void UpdateOrder(Order orderToUpdate, string orderDate)
        {
            var orders = GetAllOrders(orderDate);
            
            var existingOrder = orders.First(o => o.OrderNumber == orderToUpdate.OrderNumber);

            existingOrder.CustomerName = orderToUpdate.CustomerName;
            existingOrder.State = orderToUpdate.State;
            existingOrder.ProductType = orderToUpdate.ProductType;
            existingOrder.Area = orderToUpdate.Area;
            existingOrder.MaterialCost = orderToUpdate.CostPerSquareFoot * orderToUpdate.Area;
            existingOrder.CostPerSquareFoot = orderToUpdate.CostPerSquareFoot;
            existingOrder.LaborCostPerSquareFoot = orderToUpdate.LaborCostPerSquareFoot;
            existingOrder.LaborCost = orderToUpdate.LaborCostPerSquareFoot * orderToUpdate.Area;
            existingOrder.TaxRate = orderToUpdate.TaxRate;
            existingOrder.Tax = (orderToUpdate.MaterialCost + orderToUpdate.LaborCost) * (orderToUpdate.TaxRate / 100);
            existingOrder.Total = existingOrder.Tax + existingOrder.LaborCost + existingOrder.MaterialCost;

            OverwriteFile(orders, orderDate);
        }

        public void OverwriteFile(List<Order> orders, string orderDate)
        {
            string FilePath = @"DataFiles/Order_" + orderDate + ".txt";

            File.Delete(FilePath);

            using (var writer = File.CreateText(FilePath))
            {
                writer.WriteLine("OrderDate,OrderNumber,CustomerName,State,TaxRate,Area,ProductType,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");

                foreach (var order in orders)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", order.OrderDate, order.OrderNumber, order.CustomerName, order.State, order.TaxRate, order.Area, order.ProductType, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
                }
            }
        }

        public void NewOrderFile(Order neworder)
        {
            string path = @"DataFiles/Order_" + neworder.OrderDate + ".txt";
            neworder.OrderNumber = 0;
            using (rvar writer = File.CreateText(path))
            {
                writer.WriteLine("OrderDate,OrderNumber,CustomerName,State,TaxRate,Area,ProductType,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");

                writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", neworder.OrderDate, neworder.OrderNumber, neworder.CustomerName, neworder.State, neworder.TaxRate, neworder.Area, neworder.ProductType, neworder.CostPerSquareFoot, neworder.LaborCostPerSquareFoot, neworder.MaterialCost, neworder.LaborCost, neworder.Tax, neworder.Total);
            }
        }
           

        public List<Order> GetAllExistingOrders(Order neworder)
        {
            List<Order> orders = new List<Order>();

            string path = @"DataFiles/Order_" + neworder.OrderDate + ".txt";

            var reader = File.ReadAllLines(path);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var order = new Order();


                order.OrderDate = columns[0];
                order.OrderNumber = int.Parse(columns[1]);
                order.CustomerName = columns[2];
                order.State = columns[3];
                order.TaxRate = decimal.Parse(columns[4]);
                order.Area = decimal.Parse(columns[5]);
                order.ProductType = columns[6];
                order.CostPerSquareFoot = decimal.Parse(columns[7]);
                order.LaborCostPerSquareFoot = decimal.Parse(columns[8]);
                order.MaterialCost = decimal.Parse(columns[9]);
                order.LaborCost = decimal.Parse(columns[10]);
                order.Tax = decimal.Parse(columns[11]);
                order.Total = decimal.Parse(columns[12]);

                orders.Add(order);
            }

            return orders;
        }

        public void OverwriteExistingFile(List<Order> orders, Order neworder)
        {
            string path = @"DataFiles/Order_" + neworder.OrderDate + ".txt";
            File.Delete(path);

            using (var writer = File.CreateText(path))
            {
                writer.WriteLine("OrderDate,OrderNumber,CustomerName,State,TaxRate,Area,ProductType,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");

                foreach (var order in orders)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", order.OrderDate, order.OrderNumber, order.CustomerName, order.State, order.TaxRate, order.Area, order.ProductType, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
                }
            }
        }

        public Order DisplayLoadOrder(string orderDate, int orderNumber)
        {
                List<Order> orders = GetAllDisplayOrders(orderDate);

                return orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
        }

        public List<Order> GetAllDisplayOrders(string orderDate)
        {
            List<Order> orders = new List<Order>();

            string path = @"DataFiles/Order_" + orderDate + ".txt";

            var reader = File.ReadAllLines(path);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var order = new Order();

                order.OrderDate = columns[0];
                order.OrderNumber = int.Parse(columns[1]);
                order.CustomerName = columns[2];
                order.State = columns[3];
                order.TaxRate = decimal.Parse(columns[4]);
                order.Area = decimal.Parse(columns[5]);
                order.ProductType = columns[6];
                order.CostPerSquareFoot = decimal.Parse(columns[7]);
                order.LaborCostPerSquareFoot = decimal.Parse(columns[8]);
                order.MaterialCost = decimal.Parse(columns[9]);
                order.LaborCost = decimal.Parse(columns[10]);
                order.Tax = decimal.Parse(columns[11]);
                order.Total = decimal.Parse(columns[12]);

                orders.Add(order);
            }

            return orders;
        }

        public int GenerateOrderNumber(Order neworder)
        {
            var getAll = GetAllExistingOrders(neworder);
            List<int> orderNums = new List<int>();
            foreach (var a in getAll)
            {
                orderNums.Add(a.OrderNumber);
            }
            return orderNums.Count();
        }

        public List<Order> GetAllNonDeletedOrders(string orderDate, int orderNumber)
        {
            List<Order> orders = new List<Order>();

            string path = @"DataFiles/Order_" + orderDate + ".txt";

            var reader = File.ReadAllLines(path);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var order = new Order();


                order.OrderDate = columns[0];
                order.OrderNumber = int.Parse(columns[1]);
                order.CustomerName = columns[2];
                order.State = columns[3];
                order.TaxRate = decimal.Parse(columns[4]);
                order.Area = decimal.Parse(columns[5]);
                order.ProductType = columns[6];
                order.CostPerSquareFoot = decimal.Parse(columns[7]);
                order.LaborCostPerSquareFoot = decimal.Parse(columns[8]);
                order.MaterialCost = decimal.Parse(columns[9]);
                order.LaborCost = decimal.Parse(columns[10]);
                order.Tax = decimal.Parse(columns[11]);
                order.Total = decimal.Parse(columns[12]);

                orders.Add(order);
            }

            return orders;
        }

        public void DeleteFile(string orderDate)
        {
            File.Delete(@"DataFiles/Order_" + orderDate + ".txt");
        }
    }
}

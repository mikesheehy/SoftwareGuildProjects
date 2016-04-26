using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models;
using System.Configuration;


namespace FlooringProgram.BLL
{
    public class OrderManager
    {

        //private IOrderRepository _orderRepo;

        private IOrderRepository GetOrderRepo()
        {
            if(ConfigurationManager.AppSettings["environment"] == "prod")
            {
                return new OrderRepository();
            }
            else
            {
                //return new MockOrderRepository();
                return new MockOrderRepository();
            }
        }
        



        public Response<Order> GetOrder( string orderDate, int ordernumber)

        {
            var repo = GetOrderRepo();
            var response = new Response<Order>();

            try
            {
                var order = repo.LoadOrder(orderDate, ordernumber);


                if (order == null)
                {
                    response.Success = false;
                    response.Message = "Order was not found!";
                }
                else
                {
                    response.Success = true;
                    response.Data = order;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.Success = false;
                response.Message = "There was an error.  Please try again later.";
            }

            return response;
        }
       
        public int GenerateOrderNumber(Order neworder)
        {
            var repo = new OrderRepository();
            var getAll = repo.GetAllExistingOrders(neworder);
            List<int> orderNums = new List<int>();
            foreach (var a in getAll)
            {
                orderNums.Add(a.OrderNumber);
            }
            return orderNums.Count();
        }

        public void AddOrderToFile(Order neworder, string orderDate)
        {
            var repo = new OrderRepository();
            var getorders = repo.GetAllOrders(orderDate);
            var added = new Order
            {
                OrderDate = neworder.OrderDate,
                OrderNumber = (GenerateOrderNumber(neworder)),
                CustomerName = neworder.CustomerName,
                State = neworder.State,
                TaxRate = neworder.TaxRate,
                Area = neworder.Area,
                ProductType = neworder.ProductType,
                CostPerSquareFoot = neworder.CostPerSquareFoot,
                LaborCostPerSquareFoot = neworder.LaborCostPerSquareFoot,
                MaterialCost = neworder.MaterialCost,
                LaborCost = neworder.LaborCost,
                Tax = neworder.Tax,
                Total = neworder.Total
            };

                getorders.Add(added);

            

                repo.OverwriteFile(getorders, orderDate);

        }

        public void CreateFileForOrder(Order neworder)
        {
            string path = @"DataFiles/Order_" + neworder.OrderDate + ".txt";
            if (!System.IO.File.Exists(path))
            {
                var repo = new OrderRepository();
                repo.NewOrderFile(neworder);
                
            }
            else
            {
                var repo = new OrderRepository();
                var getorders = repo.GetAllExistingOrders(neworder);
                var toAdd = new Order
                {
                    OrderDate = neworder.OrderDate,
                    OrderNumber = (GenerateOrderNumber(neworder)),
                    CustomerName = neworder.CustomerName,
                    State = neworder.State,
                    TaxRate = neworder.TaxRate,
                    Area = neworder.Area,
                    ProductType = neworder.ProductType,
                    CostPerSquareFoot = neworder.CostPerSquareFoot,
                    LaborCostPerSquareFoot = neworder.LaborCostPerSquareFoot,
                    MaterialCost = neworder.MaterialCost,
                    LaborCost = neworder.LaborCost,
                    Tax = neworder.Tax,
                    Total = neworder.Total
                };

                getorders.Add(toAdd);

                neworder.OrderNumber = toAdd.OrderNumber;

                repo.OverwriteExistingFile(getorders, neworder);
            }
        }

        public Response<Order> DisplayGetOrder(string orderDate, int ordernumber)

        {
            var repo = new OrderRepository();
            var response = new Response<Order>();

            try
            {
                var order = repo.DisplayLoadOrder(orderDate, ordernumber);


                if (order == null)
                {
                    response.Success = false;
                    response.Message = "Order was not found!";
                }
                else
                {
                    response.Success = true;
                    response.Data = order;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.Success = false;
                response.Message = "There was an error.  Please try again later.";
            }

            return response;
        }

        public void DeleteFromList(string orderDate, int orderNumber)
        {
            var repo = new OrderRepository();
            var getorders = repo.GetAllNonDeletedOrders(orderDate, orderNumber);
            if (getorders.Count < 2)
            {
                repo.DeleteFile(orderDate);
            }
            else
            {
                getorders.RemoveAt(orderNumber - 1);
                repo.OverwriteFile(getorders, orderDate);
            }

            Console.WriteLine("Your order has been deleted.");
            Console.ReadLine();

            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;
using FlooringProgram.Data;
using System.Globalization;

namespace FlooringProgram
{
    class RemoveOrderWorkflow
    {
        private Order _deletedOrder;

        public void Execute()
        {
            //enter date of order and order number to find order
            string orderDate = GetDateFromUser();
            int orderNumber = GetOrderNumberFromUser();
            QueryAndDisplayData(orderDate, orderNumber);
            
        }

        private void QueryAndDisplayData(string orderDate, int orderNumber)
        {
            try
            {
                var order = new OrderManager();
                var response = order.DisplayGetOrder(orderDate, orderNumber);

                //var repo = new OrderRepository();
                //var getOrders = repo.GetAllOrders();
                //var custOrder = (from o in getOrders
                //                 from x in o.OrderDate
                //                 where o.OrderDate.Contains(orderDate)
                //                 select new { o.CustomerName, o.Total, o.ProductType })
                //                .FirstOrDefault();
                                
                if (response.Success)
                {
                    _deletedOrder = response.Data;

                    //PrintOrderDetails(response, orderDate);
                    //UserConfirmation();

                    PrintOrderDetails(response, orderDate);
                    UserConfirmation(orderDate, orderNumber);

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("An error occourdeddd! ");
                    Console.WriteLine("Couldn't find that orderererererer ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void UserConfirmation(string orderDate, int orderNumber)
        {
            Console.Write("You are about to delete an order on {0}. Are you sure? (Y/N)",
                orderDate);
            string confirm = Console.ReadLine();
            do
            {
                if (confirm.ToUpper() != "Y")
                {
                    Console.WriteLine("Error. Please press (Y)es to delete");
                    Console.ReadLine();
                    Console.Clear();
                    UserConfirmation(orderDate, orderNumber);
                }
                RemoveExistingOrder(orderDate, orderNumber);
            } while (confirm.ToUpper() != "Y");
        }

        private void RemoveExistingOrder(string orderDate, int orderNumber)
        {
            var manager = new OrderManager();
            manager.DeleteFromList(orderDate, orderNumber);
 
        }

        private void PrintOrderDetails(Response<Order> response, string orderDate)
        {
            var repo = new OrderRepository();
            var getOrders = repo.GetAllOrders(orderDate);
            var custOrder = getOrders.FirstOrDefault(x => x.OrderNumber == response.Data.OrderNumber);

            Console.WriteLine("Order Information: ");
            Console.WriteLine("=============================");
            Console.WriteLine("Order Number:({0})", response.Data.OrderNumber);
            Console.WriteLine("Order Name:({0})", response.Data.CustomerName);
            Console.WriteLine("Customer State of Residence:({0})", response.Data.State);
            Console.WriteLine("Product Type({0})", response.Data.ProductType);
            Console.WriteLine("Order square footage({0})", response.Data.Area);
        }

        private int GetOrderNumberFromUser()
        {
            do
            {
                Console.WriteLine("To remove an existing order you will need to enter the order number: ");
                string inputOrderNumber = Console.ReadLine();
                int orderNumber;
                bool result = int.TryParse(inputOrderNumber, out orderNumber);
                if (result == false)
                {
                    Console.WriteLine("Enter a valid order number!");
                }
                return orderNumber;
            } while (true);
        }


        private string GetDateFromUser()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Enter the date of the order(mm-dd-yyyy): ");
                string input = Console.ReadLine();
                string format = "MM-dd-yyyy";
                DateTime Date;

                if (DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out Date))
                {
                    string orderDate;
                    orderDate = Date.ToString("MM-dd-yyyy");
                    return orderDate;
                }
                else
                {
                    Console.WriteLine("There were no orders placed on that date! ");
                    Console.ReadKey();
                }
            } while (true);
        }
    }
}

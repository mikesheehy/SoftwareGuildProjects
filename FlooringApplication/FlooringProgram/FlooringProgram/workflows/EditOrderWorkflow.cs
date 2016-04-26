using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;
using System.Globalization;
using FlooringProgram.Data;

namespace FlooringProgram
{
    //1. Edit will query the user for a date and order number.

    //2. If the order exists in the file for that date it will query the user for each
    //piece of order data but display the existing data.

    //3. If the user enters something new it will replace that data, if they hit enter
    //without entering data it will leave the existing data in place.

    //For example:
    //     Enter customer name(Wise): 
    //If the user enters a new name, the name will replace Wise, otherwise
    //it will leave it as-is.


    public class EditOrderWorkflow
    {
        private Order _userOrder;

        public void Execute()
        {
            int ordernumber = GetOrderNumberFromUser();
            string orderDate = GetDateFromUser();
            QueryAndDisplayData(orderDate, ordernumber);
        }

        private void QueryAndDisplayData(string orderDate, int ordernumber)
        {
            try
            {
                var order = new OrderManager();
                var response = order.DisplayGetOrder(orderDate, ordernumber);

                if (response.Success)
                {
                    _userOrder = response.Data;
                    PrintOrderDetails(response, orderDate);
                    //OverWriteExistingOrderData();
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

        private void PrintOrderDetails(Response<Order> response, string orderDate)
        {
            var repo = new OrderRepository();
           
            var custOrder = response.Data;


            Console.WriteLine("Order Information: ");
            Console.WriteLine("=============================");
            Console.WriteLine("Order Number:({0})", response.Data.OrderNumber);

            Console.WriteLine("Order Name:({0})", response.Data.CustomerName);
            string newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName) == false)
            {
                custOrder.CustomerName = newName;
                repo.UpdateOrder(custOrder, orderDate);
            }

            Console.WriteLine("Customer State of Residence:({0})", response.Data.State);
            string newState = Console.ReadLine();
            if (string.IsNullOrEmpty(newState) == false)
            {
                custOrder.State = newState;
                repo.UpdateOrder(custOrder, orderDate);
            }


            Console.WriteLine("Product Type({0})", response.Data.ProductType);
            string newProduct = Console.ReadLine();
            if (string.IsNullOrEmpty(newProduct) == false)
            {
                custOrder.ProductType = newProduct;
                repo.UpdateOrder(custOrder, orderDate);
            }

            Console.WriteLine("Order square footage({0})", response.Data.Area);
            string newArea = Console.ReadLine();
            //parse string to decimal
            decimal areaNum;
            bool res = Decimal.TryParse(newArea, out areaNum);
            if (res == false)
            {
                Console.WriteLine("Enter a valid square footage");
            }

            custOrder.Area = areaNum;
            repo.UpdateOrder(custOrder, orderDate);
        }




        private int GetOrderNumberFromUser()
        {
            Console.WriteLine("To Edit an existing order you will need to enter the order number: ");
            string inputOrderNumber = Console.ReadLine();
            int orderNumber;
            bool result = int.TryParse(inputOrderNumber, out orderNumber);
            while (result == false)
            {
                Console.WriteLine("Enter a valid order number!");
            }
            return orderNumber;
        }


        private string GetDateFromUser()
        {
            //var repo = new OrderRepository();

            //var custOrder = response.Data;

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
                    Console.WriteLine("Please enter a properly formatted date!(mm-dd-yyyy)");
                    Console.ReadKey();
                }
            } while (true);
        }



    }
}

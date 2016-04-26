using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;
using System.Globalization;

namespace FlooringProgram
{
    //Display orders will query the user for a date and load the 
    //orders.txt file for that date if it exists.  If it does not 
    //exist, it will display an error message and return the user 
    //to the main menu.

    class DisplayOrderWorkflow
    {
        private Order _currentOrder;


            public void Execute()
        {
            int orderNumber = GetOrderNumberFromUser();
            string orderDate = GetOrderDateFromUser();
            DisplayOrderInformation(orderDate, orderNumber);
        }


        private void DisplayOrderInformation(string orderDate, int orderNumber)
        {
            var manager = new OrderManager();

            var response = manager.DisplayGetOrder(orderDate, orderNumber);

            Console.Clear();

            if (response.Success)
            {
                _currentOrder = response.Data;
                printOrderDetails();
            }
            else
            {
                Console.WriteLine("A problem occurred...");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }


    private void printOrderDetails()
        {
            Console.WriteLine("\nOrder details for order #{0}", _currentOrder.OrderNumber);
            Console.WriteLine("=============================");
            Console.WriteLine("\nOrder number: {0}", _currentOrder.OrderNumber);
            Console.WriteLine("Customer Name: {0}", _currentOrder.CustomerName);
            Console.WriteLine("Product Type: {0}", _currentOrder.ProductType);
            Console.WriteLine("Material Cost Total: {0}", _currentOrder.MaterialCost.ToString("C2"));
            Console.WriteLine("Labor Cost Total: {0}", _currentOrder.LaborCost.ToString("C2"));
            Console.WriteLine("Tax: {0}", _currentOrder.Tax.ToString("C2"));
            Console.WriteLine("Order Cost Total: {0}", _currentOrder.Total.ToString("C2"));
            Console.ReadLine();
        }

        private int GetOrderNumberFromUser()
        {
            Console.Clear();
            Console.WriteLine("To view an existing order you will need to enter the order number: ");
            string inputOrderNumber = Console.ReadLine();
            int orderNumber;
            bool result = int.TryParse(inputOrderNumber, out orderNumber);
            while (result == false)
            {
                Console.WriteLine("Enter a valid order number!");
            }
            return orderNumber;
        }

        public string GetOrderDateFromUser()
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
                    Console.WriteLine("There were no orders placed on that date! Make sure the date is formtted properly");
                    Console.ReadKey();
                }
            } while (true);
        }
    }
}




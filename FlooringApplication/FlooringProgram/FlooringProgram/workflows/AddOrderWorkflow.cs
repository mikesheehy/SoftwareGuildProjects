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
    public class AddOrderWorkflow
    {
        public void Execute(string orderDate)
        {
            CreateOrder(orderDate);
        }

        public void CreateOrder(string orderDate)
        {
            var neworder = new Order();
            Console.Clear();

            //Prompt User for needed fields   
            
            string formattedDate = DateTime.Now.ToString("MM-dd-yyyy");


            Console.WriteLine("New Order Form for {0}", formattedDate);
            Console.WriteLine("**************");
            Console.Write("Name: ");
            neworder.CustomerName = Console.ReadLine();
            Console.Write("State aabv (OH): ");
            string stateAbbreviation = Console.ReadLine();
            Console.Write("Product Type(Carpet): ");
            string productType = Console.ReadLine();

            ValiateProduct(productType);

            Console.Write("Area size (sqft): ");
            string initArea = Console.ReadLine();
            decimal initialArea;
            bool res = decimal.TryParse(initArea, out initialArea);
            if (res == false)
            {
                Console.WriteLine("Please enter a valid numeric value for area.");
            }
            decimal area = initialArea;

            var product = FindProduct(productType);

            neworder.OrderDate = formattedDate;
            neworder.Area = area;
            neworder.ProductType = productType;
            neworder.CostPerSquareFoot = product.CostPerSquareFoot;
            neworder.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;
            neworder.MaterialCost = (product.CostPerSquareFoot) * (area);
            neworder.LaborCost = (product.LaborCostPerSquareFoot) * (area);
            decimal totalnotax = neworder.MaterialCost + neworder.LaborCost;

            var tax = FindTax(stateAbbreviation);

            neworder.State = tax.StateName;
            neworder.TaxRate = (tax.TaxRate)/100;
            decimal totaltax = totalnotax * neworder.TaxRate;
            neworder.Tax = totaltax;
            decimal total = totalnotax + neworder.Tax;
            neworder.Total = total;

            //neworder.OrderNumber = (AddingOrderNumber(neworder) + 1);

            

            AddOrder(neworder);

            ConfirmNewOrder(neworder);

        }

        //public int AddingOrderNumber(Order neworder)
        //{
        //    var manager = new OrderManager();
        //    manager.GenerateOrderNumber(neworder);
        //    return (manager.GenerateOrderNumber(neworder)+1);
        //}


        public bool ValiateProduct(string productType)
        {
            //check to see if product exists
            return true;
        }

        public Product FindProduct(string productType)
        {
            var manager = new ProductManager();
            var response = manager.GetProduct(productType);
            if (response.Success)
                return response.Data;
            else
                throw new Exception("No Product");
        }

        public Tax FindTax(string stateAbbreviation)
        {
            var manager = new TaxManager();
            var response = manager.GetTax(stateAbbreviation);
            if (response.Success)
                return response.Data;
            else
            {
                throw new Exception("No Tax Information for that state");
            }
        }

        public void ConfirmNewOrder(Order neworder)
        {
            Console.WriteLine("\nOrder Date: {0}", neworder.OrderDate);
            Console.WriteLine("\nOrder#{0}", neworder.OrderNumber);
            Console.WriteLine("Customer: {0}", neworder.CustomerName);
            Console.WriteLine("State: {0}", neworder.State);
            Console.WriteLine("Tax Rate: {0}", neworder.TaxRate);
            Console.WriteLine("Area: {0}sqft", neworder.Area);
            Console.WriteLine("\nProduct Type: {0}", neworder.ProductType);
            Console.WriteLine("Material Cost: ${0} per sqft", neworder.CostPerSquareFoot);
            Console.WriteLine("Labor: ${0} per sqft", neworder.LaborCostPerSquareFoot);
            Console.WriteLine("\nTotal Material Cost: ${0}", neworder.MaterialCost);
            Console.WriteLine("Total Labor: ${0}", neworder.LaborCost);
            Console.WriteLine("Tax: {0}", neworder.Tax.ToString("C2"));
            Console.WriteLine("TOTAL: {0}", neworder.Total.ToString("C2"));
            Console.ReadLine();

        }

        public void AddOrder(Order neworder)
        {
            var manager = new OrderManager();
            //manager.AddOrderToFile(neworder);
            manager.CreateFileForOrder(neworder);
        }
    }
}

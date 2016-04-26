using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;
using System.Configuration;

namespace FlooringProgram.UI.workflows
{
    class MainMenu
    {
        //ConfigurationManager.Appsettings["keyname"];

        public void Execute(string orderDate)
        {
            do
            {
                Console.Clear();
                
                Console.WriteLine("**************************************************************************************");
                Console.WriteLine("Flooring Program");
                Console.WriteLine("\n1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("\n(Q) to Quit");
                Console.WriteLine("\n**************************************************************************************");

                Console.WriteLine("\n\nEnter Choice: ");
                string input = Console.ReadLine();



                ProcessChoice(input, orderDate);

            } while (true);

        }

        private void ProcessChoice(string choice, string orderDate)
        {
            switch (choice)
            {
                case "1":
                    var display = new DisplayOrderWorkflow();
                    display.Execute();
                    break;
                case "2":
                    var add = new AddOrderWorkflow();
                    add.Execute(orderDate);
                    break;
                case "3":
                    var edit = new EditOrderWorkflow();
                    edit.Execute();
                    break;
                case "4":
                    var remove = new RemoveOrderWorkflow();
                    remove.Execute();
                    break;
            }
        }
    }
}

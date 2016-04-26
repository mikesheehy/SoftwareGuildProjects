using System;
using FlooringProgram.UI.workflows;
using System.Configuration;

namespace FlooringProgram.UI
{
    class Program
    {


        private static string orderDate;

        static void Main(string[] args)
        {
            var menu = new MainMenu();
            menu.Execute(orderDate);
        }
    }
}

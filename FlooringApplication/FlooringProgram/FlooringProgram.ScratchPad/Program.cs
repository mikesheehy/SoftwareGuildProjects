using FlooringProgram.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.ScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new OrderRepository();
            var getOrders = repo.GetAllExistingOrders();
            var custOrder = getOrders.FirstOrDefault(x => x.OrderNumber == 1);

            custOrder.CustomerName = "Foo";

            Console.ReadLine();


        }
    }
}

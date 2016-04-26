using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models;

namespace FlooringProgram.BLL
{
    public class ProductManager
    {
        public Response<Product> GetProduct(string productType)
        {
            var repo = new ProductRepository();
            var response = new Response<Product>();

            try
            {
                var product = repo.LoadProduct(productType);


                if (product == null)
                {
                    response.Success = false;
                    response.Message = "Product was not found!";
                }
                else
                {
                    response.Success = true;
                    response.Data = product;
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

    }
}

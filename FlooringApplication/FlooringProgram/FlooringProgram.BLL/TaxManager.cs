using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models;

namespace FlooringProgram.BLL
{
    public class TaxManager
    {
        public Response<Tax> GetTax(string stateAbbreviation)
        {
            var repo = new TaxRepository();
            var response = new Response<Tax>();

            try
            {
                var tax = repo.LoadTax(stateAbbreviation);


                if (tax == null)
                {
                    response.Success = false;
                    response.Message = "Tax information was not found!";
                }
                else
                {
                    response.Success = true;
                    response.Data = tax;
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

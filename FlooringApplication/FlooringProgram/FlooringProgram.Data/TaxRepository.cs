using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using System.IO;

namespace FlooringProgram.Data
{
    public class TaxRepository
    {
        private const string FilePath = @"DataFiles\Taxes.txt";

        public List<Tax> GetAllTaxes()
        {
            List<Tax> taxes = new List<Tax>();

            var reader = File.ReadAllLines(FilePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var tax = new Tax();

                tax.StateAbbreviation = columns[0];
                tax.StateName = columns[1];
                tax.TaxRate = decimal.Parse(columns[2]);

                taxes.Add(tax);
            }

            return taxes;
        }

        public Tax LoadTax(string stateAbbreviation)
        {
            List<Tax> taxes = GetAllTaxes();
            return taxes.FirstOrDefault(t => t.StateAbbreviation == stateAbbreviation);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using System.IO;

namespace FlooringProgram.Data
{
    public class ProductRepository
    {
        private const string FilePath = @"DataFiles\Products.txt";

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            var reader = File.ReadAllLines(FilePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var product = new Product();

                product.ProductType = columns[0];
                product.CostPerSquareFoot = decimal.Parse(columns[1]);
                product.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                products.Add(product);
            }

            return products;
        }

        public Product LoadProduct(string productType)
        {
            List<Product> products = GetAllProducts();
            return products.FirstOrDefault(p => p.ProductType == productType);
        }


    }
}

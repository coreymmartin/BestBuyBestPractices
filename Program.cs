using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            //department: create department - implement it
            // product: getallproducts - implement it
            // product: create product - implement it
            // product: (bonus) update product - implement it.
            // product: (bunous bonus) delete product - implement it.

            Console.WriteLine("welome to the best buy database manager" +
                "please enter an option to continue" +
                "1: View" +
                "2: Edit" +
                "3:" +
                "4:" +
                "0: Exit");

        }
    }
}

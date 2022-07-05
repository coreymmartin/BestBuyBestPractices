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

        /*
        // from class
        var repo = new DapperDepartmentRepository(conn);
        Console.WriteLine("All departments:");
        var departments = repo.GetDepartments();
        foreach (var dept in departments){
            Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
        }
        //Console.WriteLine("What is the new department name?");
        //var deptName = Console.ReadLine();
        //repo.CreateDepartment(deptName);

        var prodRepo = new DapperProductRepository(conn);
        var products = prodRepo.GetAllProducts();
        foreach (var prod in products){
            Console.WriteLine($"{prod.ProductID}: {prod.Name}: ${prod.Price}");
        }
        Console.WriteLine("");
        Console.WriteLine("what is the name of the new product?");
        var prodName = Console.ReadLine();
        Console.WriteLine("what is the product price?");
        var prodPrice = double.Parse(Console.ReadLine());
        Console.WriteLine("what is the category id?");
        var prodCat = int.Parse(Console.ReadLine());
        prodRepo.CreateProduct(prodName, prodPrice, prodCat);

        foreach (var prod in products){
            Console.WriteLine($"{prod.ProductID}: {prod.Name}: ${prod.Price}");
        }

        // end of class
        */
        var mrMenu = new Schedule(conn);
        mrMenu.Run();

        }
    }
}

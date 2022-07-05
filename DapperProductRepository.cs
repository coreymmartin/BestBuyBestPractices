using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using System.Threading;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {

        private readonly IDbConnection _conn;

        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES(@name, @price, @categoryID);",
            new { name = name, price = price, categoryID = categoryID });
        }

        public void UpdateProduct(int productID, string nameUpdated)
        {
            _conn.Execute("UPDATE products SET Name = @nameUpdated WHERE ProductID = @productID;",
            new { nameUpdated = nameUpdated, productID = productID });
            Console.WriteLine($"product {productID} name updated...");
            Thread.Sleep(3000);
        }
        public void UpdateProduct(int productID, double priceUpdated)
        {
            _conn.Execute("UPDATE products SET Price = @priceUpdated WHERE ProductID = @productID;",
            new { nameUpdated = priceUpdated, productID = productID });
            Console.WriteLine($"product {productID} price updated...");
            Thread.Sleep(3000);
        }

        public void DeleteProduct(int productID)
        {
            _conn.Execute("DELETE FROM products WHERE ProductID = @productID;",
            new { productID = productID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }
        public IEnumerable<Product> GetSingleProduct(int productID)
        {
            return _conn.Query<Product>("SELECT * FROM products WHERE ProductID = @productID;",
                new {productID = productID});
        }
    }
}

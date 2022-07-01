using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;

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
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES(@name, @price, @categoryID);", new {name = name, price = price, categoryID = categoryID});
        }

        public void UpdateProduct(int productID, string nameUpdated)
        {
            _conn.Execute("UPDATE products SET Name = @nameUpdated WHERE ProductID = @productID;", new { nameUpdated = nameUpdated, productID = productID });
        }

        public void DeleteProduct(int productID)
        {
            _conn.Execute("Delete FROM products WHERE ProductID = @productID;", new { productID = productID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }
    }
}

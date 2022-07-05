using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        void CreateProduct(string name, double price, int categoryID);

        void UpdateProduct(int productID, string nameUpdated);

        void DeleteProduct(int productID);
        
    }
}

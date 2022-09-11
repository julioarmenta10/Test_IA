using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class ProductBLL
    {
        private ProductDAL _DAL;

        public ProductBLL()
        {
            _DAL = new ProductDAL();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var data =await _DAL.GetAllProducts();
            return data;
        }

        public async Task<Product?> GetProduct(int id)
        {
            var data = await _DAL.GetProduct(id);
            return data;
        }

        public async Task<Product?>  PutProduct(int id, Product product)
        {
            var data = await _DAL.PutProduct(id,product);
            return data;
        }

        public async Task<Product?> PostProduct(Product product)
        {
            var data = await _DAL.PostProduct(product);
            return data;
        }

        public async Task<int?> DeleteProduct(int id)
        {

            var data = await _DAL.DeleteProduct(id);
            return data;
        }

        public bool ProductExists(int id)
        {
            var data =  _DAL.ProductExists(id);
            return data;
        }

    }
}
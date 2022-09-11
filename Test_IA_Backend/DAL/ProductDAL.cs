using DAL.Entities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductDAL
    {
        private TestIAContext _context;
        public ProductDAL()
        {
            _context = new TestIAContext();
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProduct(int id)
        {
            Product? product = await _context.Products.FindAsync(id);
            return product;
        }
        public async Task<Product?> PutProduct(int id, Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> PostProduct(Product product)
        {
            if (SKUExists(product.SKU))
            {
                return null;
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return await GetProduct(product.Id);
        }

        public async Task<int?> DeleteProduct(int id)
        {

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return id;
        }
        public bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public bool SKUExists(string sku)
        {
            return (_context.Products?.Any(e => e.SKU == sku)).GetValueOrDefault();
        }
    }
}

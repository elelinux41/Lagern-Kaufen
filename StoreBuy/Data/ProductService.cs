using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace StoreBuy.Data
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }
        /*
        public async Task<List<IdentityUser>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        */
        public async Task<Product> GetProductById(int id)
        {
            Product productFromDb = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
            return productFromDb;
        }
        public async Task<Product> GetProductByName(string name)
        {
            Product productFromDb = await _context.Products.SingleOrDefaultAsync(x => x.Name == name);
            return productFromDb;
        }
        public async Task<Product> GetProductByMaxPrice(int price)
        {
            Product productFromDb = await _context.Products.SingleOrDefaultAsync(x => x.Price <= price);
            return productFromDb;
        }
        public async Task<bool> InsertProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RemoveProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

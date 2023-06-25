using Blazority;
using Microsoft.EntityFrameworkCore;

namespace StoreBuy.Data
{
	public class CostumerProduct
	{
		public int ProductId { get; set; }
		public string CostumerId { get; set; }
		public bool IsBought { get; set; } = false;
	}
	public class CostumerProductService
	{
		private readonly ApplicationDbContext _context;
		public CostumerProductService(ApplicationDbContext context)
		{
			_context = context;
		}
		private async Task<List<CostumerProduct>> CostumerProductsOfUser (Costumer user, bool? isBought)
		{
			if (isBought == null)
			{
				return await _context.CostumersProducts
					.Where(p => p.CostumerId == user.Id).ToListAsync();
			} else
			{
				return await _context.CostumersProducts
					.Where(p => p.CostumerId == user.Id && p.IsBought == isBought).ToListAsync();
			}
		}
		public async Task<bool> Buy(Costumer user)
		{
			List<CostumerProduct> costumerProducts = await CostumerProductsOfUser(user, false);
			foreach (CostumerProduct costumerProduct in costumerProducts)
			{
				costumerProduct.IsBought = true;
			}
			_context.CostumersProducts.UpdateRange(costumerProducts);
			await _context.SaveChangesAsync();
			return true;
		}
		public async Task<List<Product>> UserEntries (Costumer user, bool? isBought)
		{
			var products = new List<Product>();
			List<CostumerProduct> costumerProducts = await CostumerProductsOfUser(user, isBought);
			foreach (var costumerProduct in costumerProducts)
			{
				products.Add(await _context.Products.SingleOrDefaultAsync(p => p.Id == costumerProduct.ProductId));
			}
			return products;
		}
	}
}

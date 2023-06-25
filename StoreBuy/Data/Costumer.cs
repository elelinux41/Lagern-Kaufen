using Microsoft.AspNetCore.Identity;

namespace StoreBuy.Data;

public class Costumer : IdentityUser
{
    public int Money { get; set; }
    public List<Product> Products { get; } = new();
}

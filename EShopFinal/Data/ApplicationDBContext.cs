using EShopFinal.Models;
using Microsoft.EntityFrameworkCore;
namespace EShopMVCDotNetCore.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext (DbContextOptions<ApplicationDBContext> options): base (options)
        {

        }

        public DbSet<Banner> Banner { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<CartItem> CartItem { get; set; }



    }
}

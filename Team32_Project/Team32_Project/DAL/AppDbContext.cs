using Team32_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Team32_Project.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Reorder> Reorders { get; set; }
        public DbSet<ReorderDetail> ReorderDetails { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
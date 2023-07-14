using AssignmentNet105_Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AssignmentNet105_Shared.Data
{
    public class MyDbContext : DbContext
    {
		public MyDbContext()
		{
		}

		public MyDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetails> Billdetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetails> Cartdetails { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<FavoriteProducts> FavoriteProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=StickX;Integrated Security=True;TrustServerCertificate=True;");
		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavoriteProducts>()
              .HasKey(p => new { p.AccountID, p.ProductID });
            modelBuilder.Entity<Account>()
            .HasOne(a => a.Cart)
            .WithOne(c => c.Account)
            .HasForeignKey<Cart>(c => c.AccountID); // Specify the foreign key property
		}
	}
}

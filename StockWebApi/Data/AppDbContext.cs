using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockWebApi.Models;

namespace StockWebApi.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

            builder.Entity<Portfolio>()
                .HasOne(x => x.AppUser)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.AppUserId);

            builder.Entity<Portfolio>()
            .HasOne(x => x.Stock)
            .WithMany(u => u.Portfolios)
            .HasForeignKey(p => p.StockId);



            List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name="Admin",
                NormalizedName="ADMIN"
            },
             new IdentityRole
            {
                Name="User",
                NormalizedName="USER"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
                 }

    }
} 

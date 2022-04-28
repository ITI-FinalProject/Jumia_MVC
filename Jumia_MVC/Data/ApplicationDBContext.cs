

using Jumia_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jumia_MVC.Models.Account;

namespace Jumia_MVC.Data
{
    public class ApplicationDBContext :IdentityDbContext<ApplicationUser>
    {
         public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Images>().HasKey(e => new { e.URL, e.ProductId });
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "securuty");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "securuty");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UsersRoles", "securuty");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UsersClaims", "securuty");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UsersLogin", "securuty");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "securuty");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UsersToken", "securuty");
            base.OnModelCreating(modelBuilder);

        }


        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        // orders related tabels
        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual DbSet<FavoriteItem> FavoriteItems { get; set; }
    }

}

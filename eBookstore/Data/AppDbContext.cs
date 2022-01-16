using eBookstore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookstore.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookstore_Book>().HasKey(bb => new
            {
                bb.BookstoreId,
                bb.BookId
            });
            modelBuilder.Entity<Bookstore_Book>().HasOne(b => b.Book).WithMany(bb => bb.Bookstores_Books).HasForeignKey(b =>
             b.BookId);

            modelBuilder.Entity<Bookstore_Book>().HasOne(b => b.Bookstore).WithMany(bb => bb.Bookstores_Books).HasForeignKey(b =>
             b.BookstoreId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Bookstore> Bookstores { get; set; }
        public DbSet<Bookstore_Book> Bookstores_Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


        
    }
}

using Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Context.Context
{
    public class MainDbContext: DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
       // public DbSet<Orders_Performers> Orders_Performers { get;set; }
        //public DbSet<Order_Performers> Order_Performers { get; set; }
        public MainDbContext(DbContextOptions<MainDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(x=>x.email).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.login).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.password).IsRequired();
            modelBuilder.Entity<User>().HasIndex(x=>x.login).IsUnique();


            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(x => x.CreatorId).IsRequired();
            modelBuilder.Entity<Order>().Property(x => x.period).IsRequired();
            modelBuilder.Entity<Order>().Property(x => x.cost).IsRequired();
            modelBuilder.Entity<Order>().Property(x => x.title).IsRequired();
            modelBuilder.Entity<Order>().HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.CreatorId).OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Order_Performers>().ToTable("order_performers");
            //modelBuilder.Entity<Order_Performers>().Property(x => x.order_id).IsRequired();
            //modelBuilder.Entity<Order_Performers>().Property(x => x.performer_id).IsRequired();

        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SapphireApp.Models;
using SapphireApp.ViewModels;

namespace SapphireApp.Data
{
    public partial class SFlowerDbContext : DbContext
    {
        //public SFlowerDbContext()
        //{
        //}

        //This is the constructor we will use
        //this constructor takes options
        public SFlowerDbContext(DbContextOptions<SFlowerDbContext> options)
            : base(options)
        {
        }
        //All of our tables are listed as DbSet<Model> /lists
        public virtual DbSet<Customer> Customers { get; set; } 
        public virtual DbSet<Order> Orders { get; set; } 
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; } 

        
        //This is the method that defines the relationships between the tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_To_Customer");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_To_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_To_Product");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<SapphireApp.ViewModels.ProductCreateVM> ProductCreateVM { get; set; }
    }
}

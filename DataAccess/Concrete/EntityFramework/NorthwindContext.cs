using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    //Context,Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Username=postgres; Password=12345; Database=Northwind; Pooling=true");
        }

        //veritabanı tabloları ile eşleştirme
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<User> userss { get; set; }
        public DbSet<UserOperationClaim> user_operation_claims { get; set; }
        public DbSet<OperationClaim> operation_claims { get; set; }
    }
}

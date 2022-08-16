using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwndContext:DbContext//Bir context sınıfı olduğunu belirtmemiz için DbContext sınıfından inherit etmek gerekiyor.
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server inctance'ı, veritabanı adı, güvenlik türü(true olduğundan şifresiz veritabanına bağlanır.)
            optionsBuilder.UseSqlServer(@"Server=AHMET\SQLEXPRESS;Database=NORTHWND;Trusted_Connection=true");
        }
        //Alttaki komutlar ile bizim nesnelerimiz ile veritabanındaki tabloları eşitliyor.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


    }
}

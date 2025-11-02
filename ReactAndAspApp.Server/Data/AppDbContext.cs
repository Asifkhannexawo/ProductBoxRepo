using Microsoft.EntityFrameworkCore;
using ReactAndAspApp.Server.Models;
using System;

namespace ReactAndAspApp.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- Seed for Customer Types ---
            modelBuilder.Entity<CustomerType>().HasData(
                new CustomerType { Id = 1, Name = "Regular" },
                new CustomerType { Id = 2, Name = "Premium" },
                new CustomerType { Id = 3, Name = "Corporate" }
            );

            // --- Use a fixed date/time value to avoid dynamic model changes ---
            var fixedDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc);

            // --- Seed for Customers ---
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Alice Smith",
                    CustomerTypeId = 1,
                    Description = "First sample customer",
                    Address = "123 Main St",
                    City = "Springfield",
                    State = "IL",
                    Zip = "62701",
                    LastUpdated = fixedDate
                },
                new Customer
                {
                    Id = 2,
                    Name = "Acme Corp",
                    CustomerTypeId = 3,
                    Description = "Corporate client example",
                    Address = "456 Corporate Blvd",
                    City = "Chicago",
                    State = "IL",
                    Zip = "60601",
                    LastUpdated = fixedDate
                },
                new Customer
                {
                    Id = 3,
                    Name = "Bob Johnson",
                    CustomerTypeId = 2,
                    Description = "Premium customer",
                    Address = "789 Elm St",
                    City = "Evanston",
                    State = "IL",
                    Zip = "60201",
                    LastUpdated = fixedDate
                },
                new Customer
                {
                    Id = 4,
                    Name = "Cathy Lee",
                    CustomerTypeId = 1,
                    Description = null, // optional
                    Address = "22 Oak Ave",
                    City = "Naperville",
                    State = "IL",
                    Zip = "60540",
                    LastUpdated = fixedDate
                },
                new Customer
                {
                    Id = 5,
                    Name = "Delta LLC",
                    CustomerTypeId = 3,
                    Description = "Another corporate",
                    Address = "100 Market St",
                    City = "Aurora",
                    State = "IL",
                    Zip = "60505",
                    LastUpdated = fixedDate
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

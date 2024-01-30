using Employee_core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Employee_core.Data
{
    public class EmployeeDbContext : DbContext
    {
        // If you need IConfiguration, uncomment the following line
        // private readonly IConfiguration _configuration;

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options /*, IConfiguration configuration*/)
            : base(options)
        {
            // Uncomment the following line if you need IConfiguration
            // _configuration = configuration;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Salary)
                .WithOne(s => s.Employee)
                .HasForeignKey<Salary>(s => s.EmployeeId);  
         
            base.OnModelCreating(modelBuilder);
        }


    }
}

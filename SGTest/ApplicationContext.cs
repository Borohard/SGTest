using Microsoft.EntityFrameworkCore;
using SGTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<JobTitle> JobTitles => Set<JobTitle>();
        public DbSet<Department> Departments => Set<Department>();

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=SGTest;Username=postgres;Password=admin123");
        }
    }
}

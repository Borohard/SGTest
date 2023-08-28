using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SGTest.Models;

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
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();
            optionsBuilder.UseNpgsql(config.GetConnectionString("AppContextConnection"));
        }
    }
}

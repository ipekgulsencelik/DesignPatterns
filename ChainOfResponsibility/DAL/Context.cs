using Microsoft.EntityFrameworkCore;

namespace ChainOfResponsibility.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MSI;database=ChainOfResponsibilityDB;integrated security=true;trusted_connection=true;encrypt=false");
        }

        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}

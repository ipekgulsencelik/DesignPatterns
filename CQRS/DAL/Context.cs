using Microsoft.EntityFrameworkCore;

namespace CQRS.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MSI;database=CQRSDB;integrated security=true;trusted_connection=true;encrypt=false");
        }

        public DbSet<Product> Products { get; set; }
    }
}

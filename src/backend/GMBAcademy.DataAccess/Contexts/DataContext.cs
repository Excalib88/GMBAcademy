using GMBAcademy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GMBAcademy.DataAccess.Contexts
{
    public class DataContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public void InitDatabase()
        {
            Database.Migrate();
        }
    }
}

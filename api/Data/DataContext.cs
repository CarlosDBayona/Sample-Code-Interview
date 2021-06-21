using Microsoft.EntityFrameworkCore;
using api.Model;
namespace Api.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Company> Companies { get; set; }

        public DbSet<IdentificationType> IdentificationTypes { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
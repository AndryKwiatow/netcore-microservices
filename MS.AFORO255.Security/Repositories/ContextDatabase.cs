using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Security.Models;

namespace MS.AFORO255.Security.Repositories
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Access> Access { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Access>().ToTable("Access");
        }
    }
}

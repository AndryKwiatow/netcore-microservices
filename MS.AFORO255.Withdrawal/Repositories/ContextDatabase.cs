using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Withdrawal.Models;

namespace MS.AFORO255.Withdrawal.Repositories
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Transaction>().ToTable("Transaction");
        }
    }
}

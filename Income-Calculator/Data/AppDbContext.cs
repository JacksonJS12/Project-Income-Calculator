using Income_Calculator.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Income_Calculator.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Bank> Banks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-CPVUD3U;Database=IncomeDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}

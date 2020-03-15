using Microsoft.EntityFrameworkCore;

namespace ApiDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\Applications;Database=ApiDemo;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Candidate> Candidates { get; set; }
    }
}

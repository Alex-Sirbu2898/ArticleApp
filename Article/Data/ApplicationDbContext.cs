using Microsoft.EntityFrameworkCore;

namespace ArticleApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public const string SCHEMA = "application";
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Userid=postgres;Password=password;Database=Article");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SCHEMA);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Article> Articles { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace KRFHomepage.Infrastructure.Database.DBContext
{
    public partial class HomepageDBContext : DbContext
    {
        public HomepageDBContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.CommonModelCreating(modelBuilder);
            this.TranslationModelCreating(modelBuilder);
            this.HomepageModelCreating(modelBuilder);
        }
    }
}

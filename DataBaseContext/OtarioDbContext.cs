using Microsoft.EntityFrameworkCore;
using OtarioLearning.DataBaseContext.Configurations;
using OtarioStudy.Models;

namespace OtarioStudy.DataBaseContext
{
    public class OtarioDbContext : DbContext
    {
        public OtarioDbContext(DbContextOptions<OtarioDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Words> Words { get; set; }
        public DbSet<WordsTopic> WordsTopics { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WordsConfigurations());
            modelBuilder.ApplyConfiguration(new WordsTopicConfiguration());
        }
    }
}

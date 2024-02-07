using Microsoft.EntityFrameworkCore;
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
    }
}

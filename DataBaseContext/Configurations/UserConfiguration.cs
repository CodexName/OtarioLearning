using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtarioStudy.Models;

namespace OtarioLearning.DataBaseContext.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.PassedTopics).WithMany(x => x.Users);
        }
    }
}


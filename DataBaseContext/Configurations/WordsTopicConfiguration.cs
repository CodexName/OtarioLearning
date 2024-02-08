using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtarioStudy.Models;

namespace OtarioLearning.DataBaseContext.Configurations
{
    public class WordsTopicConfiguration : IEntityTypeConfiguration<WordsTopic>
    {
        public void Configure(EntityTypeBuilder<WordsTopic> builder)
        {
            builder.HasOne(x => x.Words).WithOne(x => x.WordsTopics);
        }
    }
}

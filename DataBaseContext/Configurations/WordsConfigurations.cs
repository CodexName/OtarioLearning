using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtarioStudy.Models;

namespace OtarioLearning.DataBaseContext.Configurations
{
    public class WordsConfigurations : IEntityTypeConfiguration<Words>
    {
        public void Configure(EntityTypeBuilder<Words> builder)
        {
            builder.HasOne(x => x.WordsTopics).WithOne(x => x.Words).HasForeignKey<WordsTopic>(x => x.ForeignWordsId);
        }
    }
}

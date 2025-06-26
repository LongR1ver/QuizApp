using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp2.Models;

namespace QuizApp2.Data.Configurations
{
    public class AnswerOptionConfiguration : IEntityTypeConfiguration<AnswerOption>
    {
        public void Configure(EntityTypeBuilder<AnswerOption> builder)
        {
            builder.Property(ao => ao.Content)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.Property(ao => ao.IsCorrect)
                   .IsRequired();
        }
    }
}

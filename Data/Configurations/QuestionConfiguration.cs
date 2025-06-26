using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp2.Models;

namespace QuizApp2.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(q => q.Content)
               .IsRequired()
               .HasMaxLength(500);

            builder.HasMany(q => q.AnswerOptions)
                   .WithOne(ao => ao.Question!)
                   .HasForeignKey(ao => ao.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp2.Models;

namespace QuizApp2.Data.Configurations
{
    public class QuizAttemptConfiguration : IEntityTypeConfiguration<QuizAttempt>
    {
        public void Configure(EntityTypeBuilder<QuizAttempt> builder)
        {
            builder.Property(qa => qa.Score)
                   .IsRequired();

            builder.HasMany(qa => qa.QuizAttemptAnswers)
                   .WithOne(qaa => qaa.QuizAttempt!)
                   .HasForeignKey(qaa => qaa.QuizAttemptId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

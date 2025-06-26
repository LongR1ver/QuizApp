using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp2.Models;

namespace QuizApp2.Data.Configurations
{
    public class QuizAttemptAnswerConfiguration : IEntityTypeConfiguration<QuizAttemptAnswer>
    {
        public void Configure(EntityTypeBuilder<QuizAttemptAnswer> builder)
        {
            builder.HasOne(a => a.QuizAttempt)
                   .WithMany(q => q.QuizAttemptAnswers)
                   .HasForeignKey(a => a.QuizAttemptId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.SelectedAnswerOption)
                   .WithMany()
                   .HasForeignKey(a => a.SelectedAnswerOptionId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

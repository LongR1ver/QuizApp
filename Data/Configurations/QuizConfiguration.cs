using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp2.Models;

namespace QuizApp2.Data.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.Property(q => q.Title)
               .IsRequired()
               .HasMaxLength(200);

            builder.HasMany(q => q.Questions)
               .WithOne(q => q.Quiz!)
               .HasForeignKey(q => q.QuizId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.QuizAttempts)
                   .WithOne(qa => qa.Quiz!)
                   .HasForeignKey(qa => qa.QuizId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

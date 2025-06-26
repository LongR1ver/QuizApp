using Microsoft.EntityFrameworkCore;
using QuizApp2.Data.Configurations;
using QuizApp2.Models;

namespace QuizApp2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<QuizAttempt> QuizAttempts { get; set; }
        public DbSet<QuizAttemptAnswer> QuizAttemptAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new QuizConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerOptionConfiguration());
            modelBuilder.ApplyConfiguration(new QuizAttemptConfiguration());
            modelBuilder.ApplyConfiguration(new QuizAttemptAnswerConfiguration());
        }

        public void SeedTestData()
        {
            if (Quizzes.Any()) return;

            var quiz = new Quiz
            {
                Title = "Basic Math Quiz",
                TimeLimit = 5,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Content = "What is 2 + 2?",
                        AnswerOptions = new List<AnswerOption>
                        {
                            new AnswerOption { Content = "3", IsCorrect = false },
                            new AnswerOption { Content = "4", IsCorrect = true },
                            new AnswerOption { Content = "5", IsCorrect = false },
                            new AnswerOption { Content = "6", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Content = "What is 10 / 2?",
                        AnswerOptions = new List<AnswerOption>
                        {
                            new AnswerOption { Content = "2", IsCorrect = false },
                            new AnswerOption { Content = "5", IsCorrect = true },
                            new AnswerOption { Content = "10", IsCorrect = false },
                            new AnswerOption { Content = "20", IsCorrect = false }
                        }
                    }
                }
            };

            Quizzes.Add(quiz);
            SaveChanges();
        }
    }
}

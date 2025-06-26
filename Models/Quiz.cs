namespace QuizApp2.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int? TimeLimit { get; set; }
        public required List<Question> Questions { get; set; }
        public List<QuizAttempt>? QuizAttempts { get; set; }
    }
}

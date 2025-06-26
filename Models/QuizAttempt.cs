namespace QuizApp2.Models
{
    public class QuizAttempt
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public Quiz? Quiz { get; set; }
        public int Score { get; set; }
        public required List<QuizAttemptAnswer> QuizAttemptAnswers { get; set; }
    }
}

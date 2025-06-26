namespace QuizApp2.Models
{
    public class QuizAttemptAnswer
    {
        public int Id { get; set; }
        public int QuizAttemptId { get; set; }
        public QuizAttempt? QuizAttempt { get; set; }
        public int? SelectedAnswerOptionId { get; set; }
        public AnswerOption? SelectedAnswerOption { get; set; }
    }
}

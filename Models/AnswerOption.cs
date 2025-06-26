namespace QuizApp2.Models
{
    public class AnswerOption
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
        public required string Content { get; set; }
        public bool IsCorrect { get; set; }
    }
}

namespace QuizApp2.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public Quiz? Quiz { get; set; }
        public required string Content { get; set; }
        public required List<AnswerOption> AnswerOptions { get; set; }
    }
}

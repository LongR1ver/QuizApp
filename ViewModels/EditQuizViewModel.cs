using System.ComponentModel.DataAnnotations;

namespace QuizApp2.ViewModels
{
    public class EditQuizViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(1000)]
        public string Title { get; set; } = string.Empty;

        public int? TimeLimit { get; set; }

        //[Required]
        public List<EditQuestionViewModel> Questions { get; set; } = new();
    }

    public class EditQuestionViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        //[Required]
        public List<EditAnswerOptionViewModel> AnswerOptions { get; set; } = new();
    }

    public class EditAnswerOptionViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }
    }
}

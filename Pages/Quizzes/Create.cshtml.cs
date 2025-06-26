using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp2.Data;
using QuizApp2.Models;
using QuizApp2.ViewModels;

namespace QuizApp2.Pages.Quizzes
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EditQuizViewModel QuizVm { get; set; } = new();

        public void OnGet()
        {
            QuizVm.Questions = new List<EditQuestionViewModel>
            {
                new EditQuestionViewModel
                {
                    AnswerOptions = Enumerable.Range(0, 4).Select(_ => new EditAnswerOptionViewModel()).ToList()
                }
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var quiz = new Quiz
            {
                Title = QuizVm.Title,
                TimeLimit = QuizVm.TimeLimit,
                Questions = QuizVm.Questions.Select(q => new Question
                {
                    Content = q.Content,
                    AnswerOptions = q.AnswerOptions.Select(a => new AnswerOption
                    {
                        Content = a.Content,
                        IsCorrect = a.IsCorrect
                    }).ToList()
                }).ToList()
            };

            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Quizzes/Index");
        }
    }
}

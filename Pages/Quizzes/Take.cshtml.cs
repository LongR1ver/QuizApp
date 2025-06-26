using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp2.Data;
using QuizApp2.Interfaces;
using QuizApp2.Models;

namespace QuizApp2.Pages.Quizzes
{
    public class TakeModel : PageModel
    {
        private readonly IQuizService _quizService;
        private readonly AppDbContext _context;

        public TakeModel(IQuizService quizService, AppDbContext context)
        {
            _quizService = quizService;
            _context = context;
        }

        [BindProperty]
        public int QuizId { get; set; }

        public Quiz? Quiz { get; set; }

        [BindProperty]
        public Dictionary<int, int> SelectedAnswers { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Quiz = await _quizService.GetQuizByIdAsync(id);
            if (Quiz == null) return NotFound();
            QuizId = id;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var quiz = await _quizService.GetQuizByIdAsync(QuizId);
            if (quiz == null) return NotFound();

            // Score calculation
            int score = 0;
            foreach (var question in quiz.Questions)
            {
                if (SelectedAnswers.TryGetValue(question.Id, out int selectedId))
                {
                    var correctOption = question.AnswerOptions.FirstOrDefault(o => o.IsCorrect);
                    if (correctOption != null && correctOption.Id == selectedId)
                    {
                        score++;
                    }
                }
            }

            // Save attempt
            var attempt = new QuizAttempt
            {
                QuizId = QuizId,
                Score = score,
                QuizAttemptAnswers = SelectedAnswers.Select(kvp => new QuizAttemptAnswer
                {
                    SelectedAnswerOptionId = kvp.Value
                }).ToList()
            };

            _context.QuizAttempts.Add(attempt);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Quizzes/Result", new { attemptId = attempt.Id });
        }
    }
}

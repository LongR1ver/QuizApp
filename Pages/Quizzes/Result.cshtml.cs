using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizApp2.Data;
using QuizApp2.Models;

namespace QuizApp2.Pages.Quizzes
{
    public class ResultModel : PageModel
    {
        private readonly AppDbContext _context;

        public ResultModel(AppDbContext context)
        {
            _context = context;
        }

        public QuizAttempt? Attempt { get; set; }

        public async Task<IActionResult> OnGetAsync(int attemptId)
        {
            Attempt = await _context.QuizAttempts
                .Include(a => a.Quiz)
                    .ThenInclude(q => q!.Questions)
                        .ThenInclude(q => q.AnswerOptions)
                .Include(a => a.QuizAttemptAnswers)
                    .ThenInclude(aa => aa.SelectedAnswerOption)
                .FirstOrDefaultAsync(a => a.Id == attemptId);

            if (Attempt == null) return NotFound();
            return Page();
        }
    }
}

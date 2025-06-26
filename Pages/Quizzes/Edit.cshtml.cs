using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizApp2.Data;
using QuizApp2.Models;
using QuizApp2.ViewModels;

namespace QuizApp2.Pages.Quizzes
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EditQuizViewModel QuizVm { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var quiz = await _context.Quizzes
                .Include(q => q.Questions)
                    .ThenInclude(q => q.AnswerOptions)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (quiz == null) return NotFound();

            QuizVm = new EditQuizViewModel
            {
                Id = quiz.Id,
                Title = quiz.Title,
                TimeLimit = quiz.TimeLimit,
                Questions = quiz.Questions.Select(q => new EditQuestionViewModel
                {
                    Id = q.Id,
                    Content = q.Content,
                    AnswerOptions = q.AnswerOptions.Select(a => new EditAnswerOptionViewModel
                    {
                        Id = a.Id,
                        Content = a.Content,
                        IsCorrect = a.IsCorrect
                    }).ToList()
                }).ToList()
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var quiz = await _context.Quizzes
                .Include(q => q.Questions)
                    .ThenInclude(q => q.AnswerOptions)
                .FirstOrDefaultAsync(q => q.Id == QuizVm.Id);

            if (quiz == null) return NotFound();

            quiz.Title = QuizVm.Title;
            quiz.TimeLimit = QuizVm.TimeLimit;

            foreach (var questionVm in QuizVm.Questions)
            {
                var existingQuestion = quiz.Questions.FirstOrDefault(q => q.Id == questionVm.Id);
                if (existingQuestion == null) continue;

                existingQuestion.Content = questionVm.Content;

                foreach (var answerVm in questionVm.AnswerOptions)
                {
                    var existingAnswer = existingQuestion.AnswerOptions.FirstOrDefault(a => a.Id == answerVm.Id);
                    if (existingAnswer == null) continue;

                    existingAnswer.Content = answerVm.Content;
                    existingAnswer.IsCorrect = answerVm.IsCorrect;
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/Quizzes/Index");
        }
    }
}

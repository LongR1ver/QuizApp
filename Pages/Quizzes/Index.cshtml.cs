using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp2.Interfaces;
using QuizApp2.Models;

namespace QuizApp2.Pages.Quizzes
{
    public class IndexModel : PageModel
    {
        private readonly IQuizService _quizService;

        public IndexModel(IQuizService quizService)
        {
            _quizService = quizService;
        }

        public List<Quiz> Quizzes { get; set; } = new();

        public async Task OnGetAsync()
        {
            Quizzes = await _quizService.GetAllQuizzesAsync();
        }
    }
}

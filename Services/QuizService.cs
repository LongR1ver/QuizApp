using Microsoft.EntityFrameworkCore;
using QuizApp2.Data;
using QuizApp2.Interfaces;
using QuizApp2.Models;

namespace QuizApp2.Services
{
    public class QuizService : IQuizService
    {
        private readonly AppDbContext _context;

        public QuizService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Quiz>> GetAllQuizzesAsync()
        {
            return await _context.Quizzes
                .Include(q => q.Questions)
                .ToListAsync();
        }

        public async Task<Quiz?> GetQuizByIdAsync(int quizId)
        {
            return await _context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.AnswerOptions)
                .FirstOrDefaultAsync(q => q.Id == quizId);
        }
    }
}

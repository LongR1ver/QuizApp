using QuizApp2.Models;

namespace QuizApp2.Interfaces
{
    public interface IQuizService
    {
        Task<List<Quiz>> GetAllQuizzesAsync();
        Task<Quiz?> GetQuizByIdAsync(int quizId);
    }
}

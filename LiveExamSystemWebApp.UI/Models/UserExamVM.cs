using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.UI.Models;

public class UserExamVM
{
    public Exam Exam { get; set; }

    public List<QuestionAndAnswer> UserAnswers { get; set; } = new List<QuestionAndAnswer>();
}

public class QuestionAndAnswer
{
    public int QuestionId { get; set; }

    public string Answer { get; set; }
}
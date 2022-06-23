using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.UI.Models;

public class ExamResultVM
{
    public string UserName { get; set; }
    public string ExamName { get; set; }
    public float Score { get; set; }

    public virtual List<QuestionResult> QuestionResults { get; set; } = new List<QuestionResult>();
}

public class QuestionResult
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string UserAnswer { get; set; }
    public string CorrectAnswer { get; set; }
    public string FileCode { get; set; }
}
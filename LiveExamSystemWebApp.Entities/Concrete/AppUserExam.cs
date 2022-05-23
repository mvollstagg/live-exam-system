using LiveExamSystemWebApp.Core.Entities;

namespace LiveExamSystemWebApp.Entities.Concrete;

public class AppUserExam : Entity
{    
    public int AppUserId { get; set; }
    public int ExamId { get; set; }
    public int RightAnswer { get; set; }
    public int WrongAnswer { get; set; }
    public int Score { get; set; }
    public virtual AppUser? AppUser { get; set; }
    public virtual Exam? Exam { get; set; }
}
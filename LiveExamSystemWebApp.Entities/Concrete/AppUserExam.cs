using LiveExamSystemWebApp.Core.Entities;

namespace LiveExamSystemWebApp.Entities.Concrete;

public class AppUserExam : Entity
{    
    public int AppUserId { get; set; }
    public int ExamId { get; set; }
    public int? RightAnswer { get; set; }
    public int? WrongAnswer { get; set; }
    public float? Score { get; set; }
    public bool IsStarted { get; set; }
    public bool IsEnd { get; set; }
    public DateTime? UserStartDate { get; set; }
    public virtual AppUser? AppUser { get; set; }
    public virtual Exam? Exam { get; set; }
}
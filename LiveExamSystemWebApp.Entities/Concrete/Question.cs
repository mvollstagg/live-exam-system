using LiveExamSystemWebApp.Core.Entities;
using System.Collections.Generic;

namespace LiveExamSystemWebApp.Entities.Concrete;

public class Question : Entity
{
    public Question()
    {
        Answers = new HashSet<Answer>();
    }

    public int ExamId { get; set; }    
    public int CategoryId { get; set; }
    public int CorrectAnswerIndex { get; set; }
    public string FileCode { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsAnnoted { get; set; }
    public virtual Category Category { get; set; }
    public virtual Exam Exam { get; set; }
    public virtual ICollection<Answer> Answers { get; set; }
}
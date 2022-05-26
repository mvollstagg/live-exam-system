using LiveExamSystemWebApp.Core.Entities;
using System.Collections.Generic;

namespace LiveExamSystemWebApp.Entities.Concrete;

public class Answer : Entity
{
    public int QuestionId { get; set; }
    public string Description { get; set; }
    public virtual Question Question { get; set; }
}
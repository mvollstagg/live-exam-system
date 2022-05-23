using LiveExamSystemWebApp.Core.Entities;
using System.Collections.Generic;

namespace LiveExamSystemWebApp.Entities.Concrete;

public class Exam : Entity
{
    public Exam()
    {
        Questions = new HashSet<Question>();
    }
    
    public int CategoryId { get; set; }
    public string FileCode { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Time { get; set; }    
    public bool IsStarted { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime UserStartDate { get; set; }
    public bool IsActived { get; set; }
    public string SlugUrl { get; set; }
    public virtual Category? Category { get; set; }
    public virtual ICollection<Question> Questions { get; set; }
}
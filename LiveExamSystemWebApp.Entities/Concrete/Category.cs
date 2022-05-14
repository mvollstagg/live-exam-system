using LiveExamSystemWebApp.Core.Entities;
using System.Collections.Generic;

namespace LiveExamSystemWebApp.Entities.Concrete;

public class Category : Entity
{
    public Category()
    {
        Exams = new HashSet<Exam>();
        Questions = new HashSet<Question>();
    }
    public int? ParentId { get; set; }
    public int OrderBy { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsActived { get; set; }
    public bool IsExam { get; set; }
    public bool IsQuestion { get; set; }
    public string SlugUrl { get; set; }
    public virtual Category Parent { get; set; }
    public virtual ICollection<Category> Children { get; set; }
    public virtual ICollection<Exam> Exams { get; set; }
    public virtual ICollection<Question> Questions { get; set; }
}
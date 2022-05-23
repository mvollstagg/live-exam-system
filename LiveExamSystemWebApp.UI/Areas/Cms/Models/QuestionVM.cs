using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.UI.Areas.Cms.Models
{
    public class QuestionVM
    {
        public Question Question { get; set; }
        public List<Category> Categories { get; set; }
        public List<Answer> Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }
    }
}

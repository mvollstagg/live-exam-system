using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.UI.Areas.Cms.Models
{
    public class ExamVM
    {
        public Exam Exam { get; set; }
        public List<Category> Categories { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
    }
}

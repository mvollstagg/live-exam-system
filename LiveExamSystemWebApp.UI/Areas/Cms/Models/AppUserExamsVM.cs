using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.UI.Areas.Cms.Models
{
    public class AppUserExamsVM
    {
        public List<AppUser> AppUsers { get; set; }
        public List<AppUserExam> AppUserExams { get; set; }
    }
}

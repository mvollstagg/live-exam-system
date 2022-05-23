using System.ComponentModel.DataAnnotations.Schema;
using LiveExamSystemWebApp.Core.Entities;

namespace LiveExamSystemWebApp.Entities.Concrete;

public class AppUser : Entity
{
    public AppUser()
    {
        AppUserExams = new HashSet<AppUserExam>();
    }
    public string FirstName { get; set; }       
    public string LastName { get; set; }
    public string Email { get; set; }        
    public string PasswordHash { get; set; }
    public string SecretKey { get; set; } = Guid.NewGuid().ToString().Replace("-", "") + DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "");
    public string Role { get; set; } = "User";
    public DateTime TokenExpiryDate { get; set; }
    public string Token { get; set; }
    public bool IsActived { get; set; }
    public virtual ICollection<AppUserExam> AppUserExams { get; set; }
    [NotMapped]
    public string Password { get; set; } // Needed for getting password from forms.
    [NotMapped]
    public string FullName{get{return this.FirstName+" "+this.LastName;} private set{}}
}
using LiveExamSystemWebApp.Core.Entities;

namespace LiveExamSystemWebApp.Entities.Concrete;
public class Letter : Entity
{
    public string FullName { get; set; }
    public string Subject { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
}

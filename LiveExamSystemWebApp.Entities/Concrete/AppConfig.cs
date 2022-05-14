using LiveExamSystemWebApp.Core.Entities;

namespace LiveExamSystemWebApp.Entities.Concrete;

public class AppConfig : Entity
{
    public string FileCode { get; set; }
    public string Twitter { get; set; }
    public string Instagram { get; set; }
    public string Linkedin { get; set; }
    public string Addres { get; set; }
    public string MapCode { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

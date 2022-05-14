using LiveExamSystemWebApp.Core.Entities;

namespace LiveExamSystemWebApp.Entities.Concrete;

public class AppSeo : Entity
{
    public string AppSeoCode { get; set; }
    public string PageName { get; set; }
    public string Title { get; set; }
    public string Keyword { get; set; }
    public string Description { get; set; }
    public bool IsActived { get; set; }
}
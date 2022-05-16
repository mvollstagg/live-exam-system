using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.UI.Areas.Cms.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveExamSystemWebApp.UI.Areas.Cms.Components;

public class VideoViewComponent : ViewComponent
{
    private readonly IDocumentService _documentService;
    public VideoViewComponent(IDocumentService documentService)
    {
        _documentService = documentService;
    }
    public async Task<IViewComponentResult> InvokeAsync(string FileCode)
    {
        var result = await _documentService.GetDocumentByIdAsync(FileCode);
        if (result.Success)
        {
            var file = result.Data;
            return View(new ImageVM()
            {
                Image = file.Video_Url
            });
        }
        return View(new ImageVM()
        {
            Image = ""
        });
    }
}
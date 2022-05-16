using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LiveExamSystemWebApp.UI.Areas.Cms.Controllers
{
    [Area("Cms")]
    [Authorize(Roles = "Admin")]
    public class AppConfigsController : Controller
    {
        private readonly IAppConfigService _appConfigService;
        private readonly IDocumentService _documentService;
        public AppConfigsController(IAppConfigService appConfigService,
            IDocumentService documentService)
        {
            _appConfigService = appConfigService;
            _documentService = documentService;
        }

        
        public async Task<IActionResult> Index()
        {
            var row = await _appConfigService.GetByAppConfigAsync();
            if (row.Success)
            {
                return View(row.Data);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AppConfig webConfig, IFormFile file)
        {
            if (webConfig.Id == 0)
            {
                if (file != null)
                {
                    webConfig.FileCode = (await _documentService.AddUploadAsync(file, "/file/logo/")).Data;
                }
                await _appConfigService.AddAsync(webConfig);
            }
            else
            {
                if (file != null)
                {
                    webConfig.FileCode = (await _documentService.UpdateUploadAsync(file, webConfig.FileCode, "/file/logo/")).Data;
                }
                await _appConfigService.UpdateAsync(webConfig);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

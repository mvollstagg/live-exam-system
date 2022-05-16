using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Entities.Concrete;
using LiveExamSystemWebApp.UI.Areas.Cms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LiveExamSystemWebApp.UI.Areas.Cms.Controllers
{
    [Area("Cms")]
    [Authorize(Roles = "Admin")]
    public class AppSeosController : Controller
    {

        private readonly ISeoService _seoService;
        public AppSeosController(ISeoService seoService)
        {
            _seoService = seoService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _seoService.GetAppSeoStaticListAsync();
            if (list.Success)
            {
                return View(list.Data);
            }
            return NotFound();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppSeoVM appSeoVM)
        {
            try
            {
                var result = await _seoService.AddAsync(new AppSeo()
                {
                    Title = appSeoVM.AppSeo.Title,
                    Description = appSeoVM.AppSeo.Description,
                    Keyword = appSeoVM.AppSeo.Keyword,
                    IsActived = appSeoVM.AppSeo.IsActived,
                    AppSeoCode = null,
                    PageName = appSeoVM.AppSeo.PageName
                });
                if (result.Success)
                {
                    TempData["Success"] = result.Message;
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
            }
            return RedirectToAction(nameof(AppSeosController.Index));
        }


        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id != null)
            {
                var appSeoRow = await _seoService.GetByAppSeoIdAsync(Id.Value);
                if (appSeoRow.Success)
                {
                    return View(new AppSeoVM()
                    {
                        AppSeo = appSeoRow.Data
                    });
                }
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppSeoVM appSeoVM)
        {
            if (appSeoVM.AppSeo.Id > 0)
            {
                try
                {
                    var appSepUpdate = await _seoService.UpdateAsync(appSeoVM.AppSeo);
                    if (appSepUpdate.Success)
                    {
                        TempData["Success"] = appSepUpdate.Message;
                    }
                    

                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
                }
                return RedirectToAction(nameof(AppSeosController.Index));
            }
            return NotFound();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var row = await _seoService.GetByAppSeoIdAsync(Id);
            if (row.Success)
            {
                row.Data.IsActived = false;
                await _seoService.DeleteAsync(row.Data);
                TempData["Success"] = Messages.DeleteMessage;
                return RedirectToAction(nameof(AppSeosController.Index));
            }
            return NotFound();
        }
    }
}

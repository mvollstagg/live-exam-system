using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LiveExamSystemWebApp.UI.Areas.Cms.Controllers
{
    [Area("Cms")]
    [Authorize(Roles = "Admin")]
    public class LetterController : Controller
    {
        private readonly ILetterService _letterService;
        public LetterController(ILetterService letterService)
        {
            _letterService = letterService;
        }
        
        public async Task<IActionResult> Index()
        {
            var result = await _letterService.GetListLangAsync();
            return View(result.Data);
        }
        
        public async Task<IActionResult> Delete(int Id)
        {
            var row = await _letterService.GetByIdAsync(Id);
            if (row.Success)
            {
                await _letterService.DeleteAsync(row.Data);
                TempData["Success"] = Messages.DeleteMessage;
                return RedirectToAction(nameof(LetterController.Index));
            }
            return NotFound();
        }
    }
}

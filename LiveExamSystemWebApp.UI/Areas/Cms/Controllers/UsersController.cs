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
    public class UsersController : Controller
    {
        private readonly IAppUserService _appUserService;
        public UsersController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        
        public async Task<IActionResult> Index()
        {
            var result = await _appUserService.GetAppUserListAsync();
            return View(result.Data);
        }
        
        // public async Task<IActionResult> Delete(int Id)
        // {
        //     var row = await _UsersService.GetByIdAsync(Id);
        //     if (row.Success)
        //     {
        //         await _UsersService.DeleteAsync(row.Data);
        //         TempData["Success"] = Messages.DeleteMessage;
        //         return RedirectToAction(nameof(UsersController.Index));
        //     }
        //     return NotFound();
        // }
    }
}

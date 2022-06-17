using System.Security.Claims;
using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Entities.Concrete;
using LiveExamSystemWebApp.UI.Areas.Cms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiveExamSystemWebApp.UI.Controllers;

[Authorize(Roles = "User")]
public class ExamController : Controller
{

    private readonly IAppUserService _appUserService;
    private readonly IExamService _examService;
    private readonly IAppUserExamService _appUserExamService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ExamController(IExamService examService, IAppUserService appUserService, IAppUserExamService appUserExamService)
    {
        _examService = examService;
        _appUserService = appUserService;
        _appUserExamService = appUserExamService;
    }
    
    public async Task<IActionResult> Index()
    {
        var user = await _appUserService.GetByUserEmailAsync(HttpContext.User.FindFirst(ClaimTypes.Email).Value);
        List<Exam> exams = new List<Exam>();
        foreach (var item in user.Data.AppUserExams)
        {
            var exam = await _examService.GetByExamIdAsync(item.ExamId);
            exams.Add(exam.Data);
        }
        if (user.Success)
        {
            return View(exams.Where(x => x.IsActived == true).ToList());
        }
        return NotFound();
    }

    public async Task<IActionResult> Exam(int? Id)
    {
        var exam = await _examService.GetByExamIdAsync(Id.Value);
        return View(exam.Data);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Exam(ExamVM examVM)
    {
        try
        {
            // if(examVM.CoverFile != null)
            // {
            //     if (!_image.IsImageValid(examVM.CoverFile))
            //     {
            //         ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
            //         return View(examVM);
            //     }
            //     else
            //     {
            //         examVM.Exam.FileCode = await _image.UploadAsync(examVM.CoverFile, "files", "exam"); 
            //     }
            // }
            
            examVM.Exam.SlugUrl = UrlSeoHelper.UrlSeo(examVM.Exam.Title);
            examVM.Exam.FileCode = UrlSeoHelper.UrlSeo(examVM.Exam.Title);
            var result = await _examService.AddAsync(examVM.Exam);
            if (result.Success)
            {
                // var seoResult = await _appSeoService.AddAsync(new AppSeo()
                // {
                //     AppSeoCode = result.Data.AppSeoCode,
                //     IsActived = true,
                //     PageName = "",
                // });
                // if (seoResult.Success)
                // {
                //     foreach (var item in examVM.AppSeoLanguages)
                //     {
                //         item.AppSeoId = seoResult.Data.Id;
                //         await _appSeoService.AddLanguageAsync(item);
                //     }
                // }
            }
            TempData["Success"] = result.Message;
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
        }

        return RedirectToAction(nameof(ExamController.Index));
    }
}
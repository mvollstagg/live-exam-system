using System.Security.Claims;
using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Entities.Concrete;
using LiveExamSystemWebApp.UI.Areas.Cms.Models;
using LiveExamSystemWebApp.UI.Models;
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
        return View(new UserExamVM() { Exam = exam.Data });
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Exam(UserExamVM examVM, List<QuestionAndAnswer> UserAnswers)
    {
        try
        {
            var user = await _appUserService.GetByUserEmailAsync(HttpContext.User.FindFirst(ClaimTypes.Email).Value);
            var exam = await _examService.GetByExamIdAsync(examVM.Exam.Id);            
            var appUserExam = user.Data.AppUserExams.FirstOrDefault(x => x.ExamId == exam.Data.Id);
            appUserExam.IsStarted = true;
            appUserExam.UserStartDate = DateTime.Now;
            
            int wrongAnswerCount = 0, correctAnswerCount = 0;
            foreach (var item in UserAnswers)
            {
                var question = exam.Data.Questions.FirstOrDefault(x => x.Id == item.QuestionId);
                if(item.Answer == question.CorrectAnswer)
                    correctAnswerCount++;
                else
                    wrongAnswerCount++;
            }
            appUserExam.RightAnswer = correctAnswerCount;
            appUserExam.WrongAnswer = wrongAnswerCount;
            appUserExam.Score = ((float)appUserExam.RightAnswer / (float)exam.Data.Questions.Count) * 100f;
            
            var result = await _appUserExamService.UpdateAsync(appUserExam);
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
using System.Security.Claims;
using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Entities.Concrete;
using LiveExamSystemWebApp.UI.Areas.Cms.Models;
using LiveExamSystemWebApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            if(!item.IsEnd)
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
        var user = await _appUserService.GetByUserEmailAsync(HttpContext.User.FindFirst(ClaimTypes.Email).Value);
        var exam = await _examService.GetByExamIdAsync(Id.Value);
        var appUserExam = user.Data.AppUserExams.FirstOrDefault(x => x.ExamId == exam.Data.Id);
        appUserExam.IsStarted = true;
        appUserExam.UserStartDate = DateTime.Now;
        await _appUserExamService.UpdateAsync(appUserExam);
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
            appUserExam.IsEnd = true;
            
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
                TempData["Success"] = result.Message;
                ExamResultVM examResultVM = new ExamResultVM(){
                    UserName = user.Data.FullName,
                    ExamName = exam.Data.Title,
                    Score = (float)appUserExam.Score
                };
                foreach (var item in exam.Data.Questions)
                {
                    examResultVM.QuestionResults.Add(new QuestionResult(){
                        Title = item.Title,
                        Description = item.Description,
                        UserAnswer = UserAnswers.FirstOrDefault(x => x.QuestionId == item.Id).Answer,
                        CorrectAnswer = item.CorrectAnswer,
                        FileCode = item.FileCode
                    });
                }
                TempData["Results"] = JsonConvert.SerializeObject(examResultVM);
                return RedirectToAction(nameof(ExamController.Result));
            }
            
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
        }

        return RedirectToAction(nameof(ExamController.Index));
    }

    public IActionResult Result()
    {
        var examResult = JsonConvert.DeserializeObject<ExamResultVM>(TempData["Results"].ToString());
        return View(examResult);
    }
}
using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Core.Utilities.Image;
using LiveExamSystemWebApp.Entities.Concrete;
using LiveExamSystemWebApp.UI.Areas.Cms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiveExamSystemWebApp.UI.Areas.Cms.Controllers
{
    [Area("Cms")]
    [Authorize(Roles = "Admin")]
    public class QuestionsController : Controller
    {

        private readonly IQuestionService _questionService;
        private readonly ISeoService _appSeoService;
        private readonly IAnswerService _answerService;
        private readonly ICategoryService _categoryService;
        private readonly IImage _image;
        public QuestionsController(IQuestionService questionService, 
                                    IAnswerService answerService, 
                                    ICategoryService categoryService, 
                                    ISeoService appSeoService,
                                    IImage image)
        {
            _questionService = questionService;
            _appSeoService = appSeoService;
            _answerService = answerService;
            _categoryService = categoryService;
            _image = image;
        }
        
        public async Task<IActionResult> Index(int? Id)
        {
            ViewBag.ExamId = Id;
            var list = await _questionService.GetQuestionListAsync();
            if (list.Success)
            {
                return View(list.Data.Where(x => x.ExamId == Id));
            }
            return NotFound();
        }

        public async Task<IActionResult> Create(int Id)
        {
            QuestionVM questionVM = new QuestionVM()
            {
                Categories = await _categoryService.GetAllCategoriesFor("question"),
                Question = new Question() { ExamId = Id }
            };
            return View(questionVM);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuestionVM questionVM)
        {
            try
            {
                if(questionVM.File != null)
                {
                    if (!_image.IsImageValid(questionVM.File))
                    {
                        ModelState.AddModelError("", "Dosya .jpg/jpeg formatında ve maksimum 5MB boyutunda olmalıdır !");
                        return View(questionVM);
                    }
                    else
                    {
                        questionVM.Question.FileCode = await _image.UploadAsync(questionVM.File, "files", "question"); 
                    }
                }
                questionVM.Question.CorrectAnswer = questionVM.Answers.ElementAt(questionVM.CorrectAnswerIndex).Description;
                questionVM.Question.Answers = questionVM.Answers;
                var result = await _questionService.AddAsync(questionVM.Question);
                if (result.Success)
                {
                    TempData["Success"] = result.Message;
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
            }
 
            return RedirectToAction(nameof(QuestionsController.Index), new { Id = questionVM.Question.ExamId });
        }

        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id != null)
            {
                var questionRow = await _questionService.GetByQuestionIdAsync(Id.Value);
                if (questionRow.Success)
                {
                    QuestionVM questionVM = new QuestionVM()
                    {
                        Categories = await _categoryService.GetAllCategoriesFor("question"),
                        Answers = questionRow.Data.Answers.ToList(),
                        Question = questionRow.Data
                    };
                    return View(questionVM);
                }
            }
            return NotFound();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(QuestionVM questionVM)
        {
            if (questionVM.Question.Id > 0)
            {
                try
                {
                    if(questionVM.File != null)
                    {
                        if (!_image.IsImageValid(questionVM.File))
                        {
                            ModelState.AddModelError("", "Dosya .jpg/jpeg formatında ve maksimum 5MB boyutunda olmalıdır !");
                            return View(questionVM);
                        }
                        else
                        {
                            _image.Delete("files", "question", questionVM.Question.FileCode);
                            questionVM.Question.FileCode = await _image.UploadAsync(questionVM.File, "files", "question"); 
                        }
                    }  

                    var questionUpdate = await _questionService.UpdateAsync(questionVM.Question);
                    if (questionUpdate.Success)
                    {
                        foreach (var item in questionVM.Answers)
                        {
                            await _answerService.UpdateAsync(item);
                        }
                    }
                    TempData["Success"] = questionUpdate.Message;
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
                }
                return RedirectToAction(nameof(QuestionsController.Index), new { Id = questionVM.Question.ExamId });
            }
            return NotFound();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var row = await _questionService.GetByQuestionIdAsync(Id);
            if (row.Success)
            {
                // row.Data.IsActived = false;
                await _questionService.DeleteAsync(row.Data);
                TempData["Success"] = Messages.DeleteMessage;
                return RedirectToAction(nameof(QuestionsController.Index));
            }
            return NotFound();
        } 

        // [HttpPost]
        // public async Task<IActionResult> Order(List<Order> orders)
        // {
        //     try
        //     {
        //         foreach (var item in orders)
        //         {
        //             var category = await _questionService.GetByQuestionId(item.Id);
        //             category.Data.OrderBy = item.Place;
        //             await _questionService.GetOrderByQuestion(category.Data);
        //         }
        //         return Ok(new
        //         {
        //             Status = 200,
        //             Message = Messages.UpdateMessage
        //         });
        //     }
        //     catch (Exception ex)
        //     {
        //         return Ok(new
        //         {
        //             Status = 404,
        //             Message = ex.Message
        //         });
        //     }
        // }
    }
}

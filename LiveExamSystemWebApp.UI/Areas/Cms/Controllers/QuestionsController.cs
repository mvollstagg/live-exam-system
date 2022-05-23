using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
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
        public QuestionsController(IQuestionService questionService, IAnswerService answerService, ICategoryService categoryService, ISeoService appSeoService)
        {
            _questionService = questionService;
            _appSeoService = appSeoService;
            _answerService = answerService;
            _categoryService = categoryService;
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
                // if(questionVM.CoverFile != null)
                // {
                //     if (!_image.IsImageValid(questionVM.CoverFile))
                //     {
                //         ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                //         return View(questionVM);
                //     }
                //     else
                //     {
                //         questionVM.Question.FileCode = await _image.UploadAsync(questionVM.CoverFile, "files", "question"); 
                //     }
                // }
                
                questionVM.Question.FileCode = UrlSeoHelper.UrlSeo(questionVM.Question.Title);
                questionVM.Question.Answers = questionVM.Answers;
                questionVM.Question.Answers.ElementAt(questionVM.CorrectAnswerIndex).IsCorrect = true;
                var result = await _questionService.AddAsync(questionVM.Question);
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
                    //     foreach (var item in questionVM.AppSeoLanguages)
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
                    // if(questionVM.CoverFile != null)
                    // {
                    //     if (!_image.IsImageValid(questionVM.CoverFile))
                    //     {
                    //         ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                    //         return View(questionVM);
                    //     }
                    //     else
                    //     {
                    //         _image.Delete("files", "question", questionVM.Question.FileCode);
                    //         questionVM.Question.FileCode = await _image.UploadAsync(questionVM.CoverFile, "files", "question"); 
                    //     }
                    // }
                    
                    // if(questionVM.PhotoFiles != null)
                    // {
                    //     var row = await _questionService.GetByQuestionId(questionVM.Question.Id);
                    //     foreach (var item in row.Data.QuestionPhotos)
                    //     {
                    //         _image.Delete("files", "question", item.FileCode); 
                    //         await _questionService.DeletePhotoAsync(item);                                                   
                    //     }
                        
                    //     foreach (var photoFile in questionVM.PhotoFiles)
                    //     {
                    //         if (!_image.IsImageValid(photoFile))
                    //         {
                    //             ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                    //             return View(questionVM);
                    //         }
                    //         else
                    //         {
                    //             QuestionPhoto newPhoto = new QuestionPhoto
                    //             {
                    //                 FileCode = await _image.UploadAsync(photoFile, "files", "question"),
                    //                 QuestionId = questionVM.Question.Id
                    //             };
                    //             questionVM.Question.QuestionPhotos.Add(newPhoto);
                    //         }
                    //     }
                    // }

                    var questionUpdate = await _questionService.UpdateAsync(questionVM.Question);
                    if (questionUpdate.Success)
                    {
                        foreach (var item in questionVM.Answers)
                        {
                            await _answerService.UpdateAsync(item);
                        }
                        // foreach (var item in questionVM.Question.QuestionPhotos)
                        // {
                        //     item.QuestionId = questionVM.Question.Id;
                        //     await _questionService.AddPhotoAsync(item);
                        // }
                        // foreach (var item in questionVM.AppSeoLanguages)
                        // {
                        //     await _appSeoService.UpdateLanguageAsync(item);
                        // }
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

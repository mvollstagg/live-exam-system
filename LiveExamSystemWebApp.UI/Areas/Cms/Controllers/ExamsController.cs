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
    public class ExamsController : Controller
    {

        private readonly IExamService _examService;
        private readonly IAppUserExamService _appUserExamService;
        private readonly IAppUserService _appUserService;
        private readonly ISeoService _appSeoService;
        private readonly ICategoryService _categoryService;
        public ExamsController(IExamService examService, 
                                ICategoryService categoryService, 
                                ISeoService appSeoService, 
                                IAppUserService appUserService, 
                                IAppUserExamService appUserExamService)
        {
            _examService = examService;
            _appSeoService = appSeoService;
            _categoryService = categoryService;
            _appUserService = appUserService;
            _appUserExamService = appUserExamService;
        }
        
        public async Task<IActionResult> Index()
        {
            var list = await _examService.GetExamListAsync();
            if (list.Success)
            {
                return View(list.Data);
            }
            return NotFound();
        }

        public async Task<IActionResult> Create()
        {
            ExamVM examVM = new ExamVM()
            {
                Categories = await _categoryService.GetAllCategoriesFor("exam"),
                Exam = null
            };
            return View(examVM);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamVM examVM)
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
 
            return RedirectToAction(nameof(ExamsController.Index));
        }

        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id != null)
            {
                var examRow = await _examService.GetByExamIdAsync(Id.Value);
                if (examRow.Success)
                {
                    ExamVM examVM = new ExamVM()
                    {
                        Categories = await _categoryService.GetAllCategoriesFor("exam"),
                        Exam = examRow.Data
                    };
                    return View(examVM);
                }
            }
            return NotFound();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExamVM examVM)
        {
            if (examVM.Exam.Id > 0)
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
                    //         _image.Delete("files", "exam", examVM.Exam.FileCode);
                    //         examVM.Exam.FileCode = await _image.UploadAsync(examVM.CoverFile, "files", "exam"); 
                    //     }
                    // }
                    
                    // if(examVM.PhotoFiles != null)
                    // {
                    //     var row = await _examService.GetByExamId(examVM.Exam.Id);
                    //     foreach (var item in row.Data.ExamPhotos)
                    //     {
                    //         _image.Delete("files", "exam", item.FileCode); 
                    //         await _examService.DeletePhotoAsync(item);                                                   
                    //     }
                        
                    //     foreach (var photoFile in examVM.PhotoFiles)
                    //     {
                    //         if (!_image.IsImageValid(photoFile))
                    //         {
                    //             ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                    //             return View(examVM);
                    //         }
                    //         else
                    //         {
                    //             ExamPhoto newPhoto = new ExamPhoto
                    //             {
                    //                 FileCode = await _image.UploadAsync(photoFile, "files", "exam"),
                    //                 ExamId = examVM.Exam.Id
                    //             };
                    //             examVM.Exam.ExamPhotos.Add(newPhoto);
                    //         }
                    //     }
                    // }
                    examVM.Exam.SlugUrl = UrlSeoHelper.UrlSeo(examVM.Exam.Title);
                    var examUpdate = await _examService.UpdateAsync(examVM.Exam);
                    if (examUpdate.Success)
                    {
                        // foreach (var item in examVM.ExamLanguages)
                        // {
                        //     await _examService.UpdateLanguageAsync(item);
                        // }
                        // foreach (var item in examVM.Exam.ExamPhotos)
                        // {
                        //     item.ExamId = examVM.Exam.Id;
                        //     await _examService.AddPhotoAsync(item);
                        // }
                        // foreach (var item in examVM.AppSeoLanguages)
                        // {
                        //     await _appSeoService.UpdateLanguageAsync(item);
                        // }
                    }
                    TempData["Success"] = examUpdate.Message;

                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
                }
                return RedirectToAction(nameof(ExamsController.Index));
            }
            return NotFound();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var row = await _examService.GetByExamIdAsync(Id);
            if (row.Success)
            {
                row.Data.IsActived = false;
                await _examService.UpdateAsync(row.Data);
                TempData["Success"] = Messages.DeleteMessage;
                return RedirectToAction(nameof(ExamsController.Index));
            }
            return NotFound();
        } 

        public async Task<IActionResult> Assign(int? Id)
        {
            if (Id != null)
            {
                ViewBag.ExamId = Id;
                return View(new AppUserExamsVM() {
                    AppUsers = (await _appUserService.GetAppUserListAsync()).Data,
                    AppUserExams = (await _appUserExamService.GetAppUserExamListAsync()).Data.Where(x => x.ExamId == Id).ToList()
                });
            }
            return NotFound();
        }
        
        public async Task<IActionResult> AssignExam(int id, string email, bool isassign)
        {
            try
            {
                var user = await _appUserService.GetByUserEmailAsync(email);
                var exam = await _examService.GetByExamIdAsync(id);
                var appUserExamRow = await _appUserExamService.GetByAppUserAndExamIdAsync(user.Data.Id, exam.Data.Id);
                
                if(isassign && appUserExamRow.Data == null)
                {
                    AppUserExam appUserExam = new AppUserExam()
                    {
                        AppUserId = user.Data.Id,
                        ExamId = exam.Data.Id,
                        IsStarted = false
                    };

                    var result = await _appUserExamService.AddAsync(appUserExam);
                    if(result.Success)
                    {
                        TempData["Success"] = "Sınav başarıyla atandı.";
                    }
                }
                else if(!isassign && appUserExamRow.Data != null)
                {
                    var result = await _appUserExamService.DeleteAsync(appUserExamRow.Data);
                    if(result.Success)
                    {
                        TempData["Success"] = "Sınav ataması kaldırıldı.";
                    }
                }
                else
                {
                    TempData["Error"] = "Bu sınav zaten kullanıcıya atanmış ya da atanmamış sınavı silmeye çalışıyorsunuz!";
                }

                return RedirectToAction("Assign", "Exams", new { Id = exam.Data.Id });
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
            }
 
            return RedirectToAction(nameof(ExamsController.Index));
        }
    }
}

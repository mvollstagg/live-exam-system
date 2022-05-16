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
    public class CategoriesController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly ISeoService _seoService;
        public CategoriesController(ICategoryService categoryService, ISeoService seoService)
        {
            _categoryService = categoryService;
            _seoService = seoService;
        }

        #region Category
        public async Task<IActionResult> Index()
        {
            var list = await _categoryService.GetCategoryListAsync();
            if (list.Success)
            {
                return View(list.Data);
            }
            return NotFound();
        }

        public IActionResult Create(int? CategoryId)
        {
            ViewData["CategoryId"] = CategoryId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryVM categoryVM)
        {
            try
            {
                var result = await _categoryService.AddAsync(new Category()
                {
                    Title = categoryVM.Category.Title,
                    Description = categoryVM.Category.Description,
                    IsExam = categoryVM.Category.IsExam,
                    IsQuestion = categoryVM.Category.IsQuestion,
                    IsActived = categoryVM.Category.IsActived,
                    SlugUrl = UrlSeoHelper.UrlSeo(categoryVM.Category.Title),
                    ParentId = categoryVM.Category.ParentId
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
            if (categoryVM.Category.ParentId != null)
                return RedirectToAction("SubCategory", "Categories", new { id = categoryVM.Category.ParentId });
            return RedirectToAction(nameof(CategoriesController.Index));
        }


        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id != null)
            {
                var categoryRow = await _categoryService.GetByCategoryIdAsync(Id.Value);
                if (categoryRow.Success)
                {
                    return View(new CategoryVM()
                    {
                        Category = categoryRow.Data
                    });
                }
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryVM categoryVM)
        {
            if (categoryVM.Category.Id > 0)
            {
                try
                {
                    categoryVM.Category.SlugUrl = UrlSeoHelper.UrlSeo(categoryVM.Category.Title);
                    var categoryUpdate = await _categoryService.UpdateAsync(categoryVM.Category);
                    if (categoryUpdate.Success)
                    {
                        TempData["Success"] = categoryUpdate.Message;
                    }
                    

                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
                }
                if (categoryVM.Category.ParentId != null)
                    return RedirectToAction("SubCategory", "Categories", new { id = categoryVM.Category.ParentId });
                return RedirectToAction(nameof(CategoriesController.Index));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Order(List<Models.Order> orders)
        {
            try
            {
                foreach (var item in orders)
                {
                    var category = await _categoryService.GetByCategoryIdAsync(item.Id);
                    category.Data.OrderBy = item.Place;
                    await _categoryService.GetOrderByCategoryAsync(category.Data);
                }
                return Ok(new
                {
                    Status = 200,
                    Message = Messages.UpdateMessage
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Status = 404,
                    ex.Message
                });
            }
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var row = await _categoryService.GetByCategoryIdAsync(Id);
            if (row.Success)
            {
                row.Data.IsActived = false;
                await _categoryService.UpdateAsync(row.Data);
                TempData["Success"] = Messages.DeleteMessage;
                if (row.Data.ParentId != null)
                    return RedirectToAction("SubCategory", "Categories", new { id = row.Data.ParentId });
                return RedirectToAction(nameof(CategoriesController.Index));
            }
            return NotFound();
        }
        #endregion

        #region SubCatgory
        public async Task<IActionResult> SubCategory(int? Id)
        {
            if (Id != null)
            {
                var categoryList = await _categoryService.GetCategoryParentListAsync(Id.Value);
                
                if (categoryList.Success)
                {
                    ViewData["CategoryId"] = Id.Value;
                    return View(categoryList.Data);
                }
                return NotFound();
            }
            return NotFound();
        }
        #endregion
    }
}

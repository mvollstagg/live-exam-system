using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.DataAccess.Abstract;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;
    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }
    public async Task<IDataResult<Category>> AddAsync(Category category)
    {
        category.SlugUrl = UrlSeoHelper.UrlSeo(category.SlugUrl);
        await _categoryDal.AddAsync(category);
        return new SuccessDataResult<Category>(category, Messages.AddMessage);
    }

    public async Task<IResult> DeleteAsync(Category category)
    {
        await _categoryDal.UpdateAsync(category);
        return new SuccessResult(Messages.DeleteMessage);
    }

    public async Task<IDataResult<Category>> GetByCategoryIdAsync(int CategoryId)
    {
        var result = await _categoryDal.GetFirstOrDefaultAsync(x => x.Id == CategoryId, x => x.Parent);
        return result != null ? new SuccessDataResult<Category>(result) : new ErrorDataResult<Category>(Messages.RecordMessage);
    }

    public async Task<IDataResult<List<Category>>> GetCategoryListAsync()
    {
        var resultList = await _categoryDal.GetListAsync(x => x.IsActived == true && x.ParentId == null,
            x => x.OrderBy(x => x.OrderBy),
            x => x.Children);
        return new SuccessDataResult<List<Category>>(resultList.ToList());
    }

    public async Task<IDataResult<List<Category>>> GetCategoryParentListAsync(int CategoryId)
    {
        var resultList = await _categoryDal.GetListAsync(x => x.IsActived == true && x.ParentId == CategoryId,
            x => x.OrderBy(x => x.OrderBy),
            x => x.Parent);
        return new SuccessDataResult<List<Category>>(resultList.ToList());
    }

    public async Task<IResult> GetOrderByCategoryAsync(Category category)
    {
        await _categoryDal.UpdateAsync(category);
        return new SuccessResult(Messages.UpdateMessage);
    }

    public async Task<IResult> UpdateAsync(Category category)
    {
        category.SlugUrl = UrlSeoHelper.UrlSeo(category.SlugUrl);
        await _categoryDal.UpdateAsync(category);
        return new SuccessResult(Messages.UpdateMessage);
    }
}
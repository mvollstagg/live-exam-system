using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Abstract;

public interface ICategoryService
{
    Task<IDataResult<Category>> GetByCategoryIdAsync(int CategoryId);
    Task<IDataResult<List<Category>>> GetCategoryListAsync();
    Task<IDataResult<List<Category>>> GetCategoryParentListAsync(int CategoryId);
    Task<IDataResult<Category>> AddAsync(Category category);
    Task<IResult> UpdateAsync(Category category);
    Task<IResult> DeleteAsync(Category category);
    Task<IResult> GetOrderByCategoryAsync(Category category);
}

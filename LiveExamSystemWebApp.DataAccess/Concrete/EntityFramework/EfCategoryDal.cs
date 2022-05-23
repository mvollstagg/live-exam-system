using LiveExamSystemWebApp.Core.DataAccess.EntityFramework;
using LiveExamSystemWebApp.DataAccess.Abstract;
using LiveExamSystemWebApp.DataAccess.Concrete.EntityFramework.Context;
using LiveExamSystemWebApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace LiveExamSystemWebApp.DataAccess.Concrete.EntityFramework;

public class EfCategoryDal : EfEntityRepositoryBaseAsync<Category, LiveExamSystemContext>, ICategoryDal
{
    public async Task<List<Category>> GetAllCategoriesFor(string predicate)
    {
        using var context = new LiveExamSystemContext();
        if(predicate == "exam")
        {
            var results = await context.Categories
            .Where(x => x.IsActived == true && x.IsExam == true)
            .ToListAsync();
            return results;
        }
        if(predicate == "question")
        {
            var results = await context.Categories
            .Where(x => x.IsActived == true && x.IsQuestion == true)
            .ToListAsync();
            return results;
        }
        return null;
    }
}
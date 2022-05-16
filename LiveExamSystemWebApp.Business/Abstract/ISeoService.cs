using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Abstract;

public interface ISeoService
{
    Task<IDataResult<AppSeo>> GetByAppSeoIdAsync(int SeoId);
    Task<IDataResult<AppSeo>> GetBySeoCodeAsync(string SeoCode);
    Task<IDataResult<AppSeo>> GetByPageNameAsync(string PageName);
    Task<IDataResult<List<AppSeo>>> GetAppSeoStaticListAsync();
    Task<IDataResult<AppSeo>> AddAsync(AppSeo appSeo);
    Task<IResult> UpdateAsync(AppSeo appSeo);
    Task<IResult> DeleteAsync(AppSeo appSeo);
}

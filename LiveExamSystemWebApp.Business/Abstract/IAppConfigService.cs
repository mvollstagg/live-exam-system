using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Abstract;

public interface IAppConfigService
{
    Task<IDataResult<AppConfig>> GetByAppConfigIdAsync(int AppConfigId);
    Task<IDataResult<AppConfig>> GetByAppConfigAsync();
    Task<IResult> AddAsync(AppConfig appConfig);
    Task<IResult> UpdateAsync(AppConfig appConfig);
}
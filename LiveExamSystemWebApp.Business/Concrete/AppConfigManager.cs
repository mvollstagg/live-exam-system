using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.DataAccess.Abstract;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Concrete;

public class AppConfigManager : IAppConfigService
{
    private readonly IAppConfigDal _appConfigDal;
    public AppConfigManager(IAppConfigDal appConfigDal)
    {
        _appConfigDal = appConfigDal;
    }
    public async Task<IResult> AddAsync(AppConfig appConfig)
    {
        await _appConfigDal.AddAsync(appConfig);
        return new SuccessResult(Messages.AddMessage);
    }

    public async Task<IDataResult<AppConfig>> GetByAppConfigAsync()
    {
        var row = await _appConfigDal.GetFirstOrDefaultAsync();
        if (row != null)
        {
            return new SuccessDataResult<AppConfig>(row);
        }
        return new ErrorDataResult<AppConfig>(new AppConfig(), Messages.RecordMessage);
    }

    public async Task<IDataResult<AppConfig>> GetByAppConfigIdAsync(int AppConfigId)
    {
        var row = await _appConfigDal.GetFirstOrDefaultAsync(x => x.Id == AppConfigId);
        if (row != null)
        {
            return new SuccessDataResult<AppConfig>(row);
        }
        return new ErrorDataResult<AppConfig>(new AppConfig(), Messages.RecordMessage);
    }

    public async Task<IResult> UpdateAsync(AppConfig appConfig)
    {
        await _appConfigDal.UpdateAsync(appConfig);
        return new SuccessResult(Messages.UpdateMessage);
    }
}
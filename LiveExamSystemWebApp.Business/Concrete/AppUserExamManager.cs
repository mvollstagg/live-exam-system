using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.DataAccess.Abstract;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Concrete;

public class AppUserExamManager : IAppUserExamService
{
    private readonly IAppUserExamDal _appUserExamDal;
    public AppUserExamManager(IAppUserExamDal appUserExamDal)
    {
        _appUserExamDal = appUserExamDal;
    }
    public async Task<IDataResult<AppUserExam>> AddAsync(AppUserExam appUserExam)
    {
        await _appUserExamDal.AddAsync(appUserExam);
        return new SuccessDataResult<AppUserExam>(appUserExam, Messages.AddMessage);
    }

    public async Task<IResult> DeleteAsync(AppUserExam appUserExam)
    {
        await _appUserExamDal.RemoveAsync(appUserExam);
        return new SuccessResult(Messages.DeleteMessage);
    }

    public async Task<IDataResult<AppUserExam>> GetByAppUserExamIdAsync(int AppUserExamId)
    {
        var result = await _appUserExamDal.GetFirstOrDefaultAsync(x => x.Id == AppUserExamId);
        return result != null ? new SuccessDataResult<AppUserExam>(result) : new ErrorDataResult<AppUserExam>(Messages.RecordMessage);
    }

    public async Task<IDataResult<AppUserExam>> GetByAppUserAndExamIdAsync(int AppUserExamId, int ExamId)
    {
        var result = await _appUserExamDal.GetFirstOrDefaultAsync(x => x.AppUserId == AppUserExamId && x.ExamId == ExamId);
        return result != null ? new SuccessDataResult<AppUserExam>(result) : new ErrorDataResult<AppUserExam>(Messages.RecordMessage);
    }

    public async Task<IDataResult<List<AppUserExam>>> GetAppUserExamListAsync()
    {
        var resultList = await _appUserExamDal.GetListAsync();
        return new SuccessDataResult<List<AppUserExam>>(resultList.ToList());
    }

    public async Task<IResult> UpdateAsync(AppUserExam appUserExam)
    {
        await _appUserExamDal.UpdateAsync(appUserExam);
        return new SuccessResult(Messages.UpdateMessage);
    }
}
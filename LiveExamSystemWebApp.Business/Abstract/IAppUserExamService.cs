using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Abstract;

public interface IAppUserExamService
{
    Task<IDataResult<AppUserExam>> GetByAppUserExamIdAsync(int AppUserExamId);
    Task<IDataResult<AppUserExam>> GetByAppUserAndExamIdAsync(int AppUserId, int ExamId);
    Task<IDataResult<List<AppUserExam>>> GetAppUserExamListAsync();
    Task<IDataResult<AppUserExam>> AddAsync(AppUserExam AppUserExam);
    Task<IResult> UpdateAsync(AppUserExam AppUserExam);
    Task<IResult> DeleteAsync(AppUserExam AppUserExam);
}

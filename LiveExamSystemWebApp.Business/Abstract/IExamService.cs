using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Abstract;

public interface IExamService
{
    Task<IDataResult<Exam>> GetByExamIdAsync(int examId);
    Task<IDataResult<List<Exam>>> GetExamListAsync();
    Task<IDataResult<Exam>> AddAsync(Exam exam);
    Task<IResult> UpdateAsync(Exam exam);
    Task<IResult> DeleteAsync(Exam exam);
}

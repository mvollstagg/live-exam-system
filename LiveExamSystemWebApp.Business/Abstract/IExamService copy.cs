using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Abstract;

public interface IQuestionService
{
    Task<IDataResult<Question>> GetByQuestionIdAsync(int questionId);
    Task<IDataResult<List<Question>>> GetQuestionListAsync();
    Task<IDataResult<Question>> AddAsync(Question question);
    Task<IResult> UpdateAsync(Question question);
    Task<IResult> DeleteAsync(Question question);
}

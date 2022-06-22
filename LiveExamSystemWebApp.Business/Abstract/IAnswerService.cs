using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Abstract;

public interface IAnswerService
{
    Task<IDataResult<Answer>> GetByAnswerIdAsync(int answerId);
    Task<IDataResult<List<Answer>>> GetAnswerListAsync();
    Task<IDataResult<List<Answer>>> GetAnswerListByQuestionIdAsync(int questionId);
    Task<IDataResult<Answer>> AddAsync(Answer answer);
    Task<IResult> UpdateAsync(Answer answer);
    Task<IResult> DeleteAsync(Answer answer);
}

using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.DataAccess.Abstract;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Concrete;

public class QuestionManager : IQuestionService
{
    private readonly IQuestionDal _questionDal;
    public QuestionManager(IQuestionDal questionDal)
    {
        _questionDal = questionDal;
    }
    public async Task<IDataResult<Question>> AddAsync(Question question)
    {
        await _questionDal.AddAsync(question);
        return new SuccessDataResult<Question>(question, Messages.AddMessage);
    }

    public async Task<IResult> DeleteAsync(Question question)
    {
        await _questionDal.UpdateAsync(question);
        return new SuccessResult(Messages.DeleteMessage);
    }

    public async Task<IDataResult<Question>> GetByQuestionIdAsync(int QuestionId)
    {
        var result = await _questionDal.GetFirstOrDefaultAsync(x => x.Id == QuestionId);
        return result != null ? new SuccessDataResult<Question>(result) : new ErrorDataResult<Question>(Messages.RecordMessage);
    }

    public async Task<IDataResult<List<Question>>> GetQuestionListAsync()
    {
        var resultList = await _questionDal.GetListAsync();
        return new SuccessDataResult<List<Question>>(resultList.ToList());
    }

    public async Task<IResult> UpdateAsync(Question question)
    {
        await _questionDal.UpdateAsync(question);
        return new SuccessResult(Messages.UpdateMessage);
    }
}
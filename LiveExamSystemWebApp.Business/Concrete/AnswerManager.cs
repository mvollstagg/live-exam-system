using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.DataAccess.Abstract;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Concrete;

public class AnswerManager : IAnswerService
{
    private readonly IAnswerDal _answerDal;
    public AnswerManager(IAnswerDal answerDal)
    {
        _answerDal = answerDal;
    }
    public async Task<IDataResult<Answer>> AddAsync(Answer answer)
    {
        await _answerDal.AddAsync(answer);
        return new SuccessDataResult<Answer>(answer, Messages.AddMessage);
    }

    public async Task<IResult> DeleteAsync(Answer answer)
    {
        await _answerDal.UpdateAsync(answer);
        return new SuccessResult(Messages.DeleteMessage);
    }

    public async Task<IDataResult<Answer>> GetByAnswerIdAsync(int AnswerId)
    {
        var result = await _answerDal.GetFirstOrDefaultAsync(x => x.Id == AnswerId);
        return result != null ? new SuccessDataResult<Answer>(result) : new ErrorDataResult<Answer>(Messages.RecordMessage);
    }

    public async Task<IDataResult<List<Answer>>> GetAnswerListAsync()
    {
        var resultList = await _answerDal.GetListAsync();
        return new SuccessDataResult<List<Answer>>(resultList.ToList());
    }

    public async Task<IResult> UpdateAsync(Answer answer)
    {
        await _answerDal.UpdateAsync(answer);
        return new SuccessResult(Messages.UpdateMessage);
    }
}
using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.DataAccess.Abstract;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Concrete;

public class LetterManager : ILetterService
{
    private readonly ILetterDal _letterDal;
    public LetterManager(ILetterDal letterDal)
    {
        _letterDal = letterDal;
    }
    public async Task<IResult> AddAsync(Letter letter)
    {
        await _letterDal.AddAsync(letter);
        return new SuccessResult(Messages.AddMessage);
    }

    public async Task<IDataResult<List<Letter>>> GetListLangAsync()
    {
        var letterList = await _letterDal.GetListAsync();
        return new SuccessDataResult<List<Letter>>(letterList.ToList());
    }

    public async Task<IResult> DeleteAsync(Letter letter)
    {
        await _letterDal.RemoveAsync(letter);
        return new SuccessResult(Messages.UpdateMessage);
    }

    public async Task<IDataResult<Letter>> GetByIdAsync(int Id)
    {
        var result = await _letterDal.GetFirstOrDefaultAsync(x => x.Id == Id);
        return result != null ? new SuccessDataResult<Letter>(result) : new ErrorDataResult<Letter>(Messages.RecordMessage);
    }
}
using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Abstract;

public interface ILetterService
{
    Task<IDataResult<List<Letter>>> GetListLangAsync();
    Task<IDataResult<Letter>> GetByIdAsync(int Id);
    Task<IResult> AddAsync(Letter letter);
    Task<IResult> DeleteAsync(Letter letter);
}
using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Abstract;

public interface IAppUserService
{
    Task<IDataResult<AppUser>> SignInAsync(AppUser appUser);
    Task<IDataResult<List<AppUser>>> GetAppUserListAsync();
    Task<IDataResult<AppUser>> GetByUserEmailAsync(string email);
    Task<IDataResult<AppUser>> GetByUserTokenAsync(string token);
    Task<IDataResult<AppUser>> AddAsync(AppUser AppUser);
    Task<IResult> UpdateAsync(AppUser AppUser);
    Task<IResult> DeleteAsync(AppUser AppUser);
}

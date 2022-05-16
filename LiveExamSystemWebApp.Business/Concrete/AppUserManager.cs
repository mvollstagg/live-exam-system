using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.DataAccess.Abstract;
using LiveExamSystemWebApp.Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using LiveExamSystemWebApp.Core.Utilities.Security.Hashing;

namespace LiveExamSystemWebApp.Business.Concrete;

partial class AppUserManager : IAppUserService
{
    private readonly IAppUserDal _appUserDal;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AppUserManager(IAppUserDal appUserDal, IHttpContextAccessor httpContextAccessor)
    {
        _appUserDal = appUserDal;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<IDataResult<AppUser>> SignInAsync(AppUser appUser)
    {
        var row = await _appUserDal.GetFirstOrDefaultAsync(x => x.Email == appUser.Email.Trim());
        if (row != null && HashingHelper.VerifyPasswordHashOld(appUser.Password, row.SecretKey, row.PasswordHash))
        {
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, row.FirstName),
                new Claim(ClaimTypes.Email, row.Email),
                new Claim(ClaimTypes.Role, row.Role)
            }, CookieAuthenticationDefaults.AuthenticationScheme);
            bool isAuthenticated = true;
            var principal = new ClaimsPrincipal(identity);
            if (isAuthenticated)
            {
                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddDays(1),
                    IsPersistent = true,
                    AllowRefresh = false
                });
                return new SuccessDataResult<AppUser>(row, Messages.SuccesfulLogin);
            }
        }
        return new ErrorDataResult<AppUser>(new AppUser(), Messages.UserNotFound);
    }

    public async Task<IDataResult<List<AppUser>>> GetAppUserListAsync()
    {
        var userList = await _appUserDal.GetListAsync();
        return new SuccessDataResult<List<AppUser>>(userList.ToList());
    }

    public async Task<IDataResult<AppUser>> GetByUserEmailAsync(string email)
    {
        var row = await _appUserDal.GetFirstOrDefaultAsync(x => x.Email == email);
        if (row != null)
        {
            return new SuccessDataResult<AppUser>(row);
        }
        return new ErrorDataResult<AppUser>(new AppUser(), Messages.RecordMessage);
    }

    public async Task<IDataResult<AppUser>> GetByUserTokenAsync(string token)
    {
        var row = await _appUserDal.GetFirstOrDefaultAsync(x => x.Token == token);
        if (row != null)
        {
            return new SuccessDataResult<AppUser>(row);
        }
        return new ErrorDataResult<AppUser>(new AppUser(), Messages.RecordMessage);
    }

    public async Task<IDataResult<AppUser>> AddAsync(AppUser appUser)
    {
        await _appUserDal.AddAsync(appUser);
        return new SuccessDataResult<AppUser>(appUser, Messages.AddMessage);
    }

    public async Task<IResult> UpdateAsync(AppUser appUser)
    {
        await _appUserDal.UpdateAsync(appUser);
        return new SuccessResult(Messages.UpdateMessage);
    }

    public async Task<IResult> DeleteAsync(AppUser appUser)
    {
        await _appUserDal.UpdateAsync(appUser);
        return new SuccessResult(Messages.DeleteMessage);
    }
}
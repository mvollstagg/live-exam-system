using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.DataAccess.Abstract;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Concrete;

public class SeoManager : ISeoService
{
    private readonly ISeoDal _seoDal;
    public SeoManager(ISeoDal seoDal)
    {
        _seoDal = seoDal;
    }
    public async Task<IDataResult<AppSeo>> AddAsync(AppSeo appSeo)
    {
        await _seoDal.AddAsync(appSeo);
        return new SuccessDataResult<AppSeo>(appSeo, Messages.AddMessage);
    }

    public async Task<IResult> DeleteAsync(AppSeo appSeo)
    {
        await _seoDal.UpdateAsync(appSeo);
        return new SuccessResult(Messages.DeleteMessage);
    }

    public async Task<IDataResult<List<AppSeo>>> GetAppSeoStaticListAsync()
    {
        return new SuccessDataResult<List<AppSeo>>((await _seoDal.GetListAsync(x => x.IsActived == true,
            x => x.OrderBy(x => x.Id))).ToList());
    }

    public async Task<IDataResult<AppSeo>> GetByAppSeoIdAsync(int SeoId)
    {
        var row = await _seoDal.GetFirstOrDefaultAsync(x => x.Id == SeoId);
        if (row != null)
        {
            return new SuccessDataResult<AppSeo>(row);
        }
        return new ErrorDataResult<AppSeo>(new AppSeo(), Messages.RecordMessage);
    }

    // public async Task<string> PageSeoAdd(string SeoCode, List<AppSeoLanguage> appSeoLanguages)
    // {
    //     if (SeoCode == string.Empty || SeoCode == null)
    //     {
    //         string code = GetId();
    //         var result = await AddAsync(new AppSeo()
    //         {
    //             AppSeoCode = code,
    //             IsActived = true,
    //             IsDinamicPage = true,
    //             IsStaticPage = false,
    //         });
    //         if (result.Success)
    //         {
    //             foreach (var item in appSeoLanguages)
    //             {
    //                 item.AppSeoId = result.Data.Id;
    //                 await AddLanguageAsync(item);
    //             }
    //         }
    //         return code;
    //     }
    //     foreach (var item in appSeoLanguages)
    //     {
    //         await UpdateLanguageAsync(item);
    //     }
    //     return SeoCode;
    // }

    public async Task<IResult> UpdateAsync(AppSeo appSeo)
    {
        await _seoDal.UpdateAsync(appSeo);
        return new SuccessResult(Messages.UpdateMessage);
    }
    private static string GetId()
    {
        return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
    }

    public async Task<IDataResult<AppSeo>> GetBySeoCodeAsync(string SeoCode)
    {
        var row = await _seoDal.GetFirstOrDefaultAsync(x => x.AppSeoCode == SeoCode);
        return new SuccessDataResult<AppSeo>(row);
    }

    public async Task<IDataResult<AppSeo>> GetByPageNameAsync(string PageName)
    {
        var row = await _seoDal.GetFirstOrDefaultAsync(x => x.PageName == PageName);
        if (row != null)
        {
            return new SuccessDataResult<AppSeo>(row);
        }
        return new ErrorDataResult<AppSeo>(new AppSeo(), Messages.RecordMessage);
    }
}
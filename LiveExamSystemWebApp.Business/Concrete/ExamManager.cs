using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Contants;
using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.DataAccess.Abstract;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.Business.Concrete;

public class ExamManager : IExamService
{
    private readonly IExamDal _examDal;
    private readonly IAnswerDal _answerDal;
    public ExamManager(IExamDal examDal, IAnswerDal answerDal)
    {
        _examDal = examDal;
        _answerDal = answerDal;
    }
    public async Task<IDataResult<Exam>> AddAsync(Exam exam)
    {
        exam.SlugUrl = UrlSeoHelper.UrlSeo(exam.SlugUrl);
        await _examDal.AddAsync(exam);
        return new SuccessDataResult<Exam>(exam, Messages.AddMessage);
    }

    public async Task<IResult> DeleteAsync(Exam exam)
    {
        await _examDal.UpdateAsync(exam);
        return new SuccessResult(Messages.DeleteMessage);
    }

    public async Task<IDataResult<Exam>> GetByExamIdAsync(int ExamId)
    {
        var result = await _examDal.GetFirstOrDefaultAsync(x => x.Id == ExamId, x => x.Category, x => x.Questions);
        foreach (var item in result.Questions)
        {
            item.Answers = await _answerDal.GetListAsync(x => x.QuestionId == item.Id);
        }
        return result != null ? new SuccessDataResult<Exam>(result) : new ErrorDataResult<Exam>(Messages.RecordMessage);
    }

    public async Task<IDataResult<List<Exam>>> GetExamListAsync()
    {
        var resultList = await _examDal.GetListAsync(x => x.IsActived == true, null, x => x.Category);
        return new SuccessDataResult<List<Exam>>(resultList.ToList());
    }

    public async Task<IResult> UpdateAsync(Exam exam)
    {
        exam.SlugUrl = UrlSeoHelper.UrlSeo(exam.SlugUrl);
        await _examDal.UpdateAsync(exam);
        return new SuccessResult(Messages.UpdateMessage);
    }
}
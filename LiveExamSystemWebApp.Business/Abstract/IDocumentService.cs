using LiveExamSystemWebApp.Core.Utilities.Result;
using LiveExamSystemWebApp.Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace LiveExamSystemWebApp.Business.Abstract;

public interface IDocumentService
{
    Task<IDataResult<Document>> GetDocumentByIdAsync(string DocumentUnique);
    Task<IDataResult<List<Document>>> GetDocumentListAsync();
    Task<IDataResult<string>> AddUploadAsync(IFormFile file, string FolderName, string Image_Url = null, string Video_Url = null);
    Task<IDataResult<string>> UpdateUploadAsync(IFormFile file, string DocumentUnique, string FolderName, string Image_Url = null, string Video_Url = null);
    Task<IDataResult<string>> DeleteUploadAsync(string DocumentUnique);
}

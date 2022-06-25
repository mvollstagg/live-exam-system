using Microsoft.AspNetCore.Http;

namespace LiveExamSystemWebApp.Core.Utilities.Image;

public interface IImage
{
    public Task<string> UploadAsync(IFormFile file, string outerFolderName, string innerFolderName);
    public void Delete(string outerFolderName, string innerFolderName, string fileName);
    public bool IsImageValid(IFormFile file);
}
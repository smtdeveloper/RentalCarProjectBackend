
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {

        IDataResult<string> Upload(IFormFile file, string path, string fileType);
        IResult Delete(string path, string file);
        IResult Move(string oldPath, string newPath);
        IDataResult<string> FileControl(IFormFile file, string[] fileExtention);
        IDataResult<string[]> FileExtensionRotates(string FileType);
    }
}
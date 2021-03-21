using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
   public  class FileHelper
    {


        public static string Add(IFormFile file)
        {
            string sourcepath = Path.GetTempFileName();

            if (file != null)
            {
                using (var Upload = new FileStream(sourcepath, FileMode.Create)) { file.CopyTo(Upload); }
            }
            string filepath = FilePath(file);
            File.Move(sourcepath, filepath);
            return filepath;

        }

        public static IResult Delete(string path)
        {
            File.Delete(path);
            return new SuccessResult();
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            string result = FilePath(file);
            if (sourcePath.Length != 0)
            {
                using (var Upload = new FileStream(result, FileMode.Create)) { file.CopyTo(Upload); }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string FilePath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            string path = Environment.CurrentDirectory + @"\Images";
            string newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}

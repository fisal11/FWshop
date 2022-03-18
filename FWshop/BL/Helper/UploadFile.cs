using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace FWshop.BL.Helper
{
    public  static class UploadFile
    {
        public static string SavaFile(IFormFile FileUrl, string FoldePath)
        {
            try {
                // Directory File
                string FilePath = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FoldePath;
                // file name
                string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName);

                // Merge Directory photo with file name

                string path = Path.Combine(FilePath, FileName);

                // file photo as streem 
                using (var streem = new FileStream(path, FileMode.Create))
                {
                    FileUrl.CopyTo(streem);
                }
                return FileName;

            }
            catch(Exception ex)
            {
                return "";
            }
           
         }

        public static void DeleteFile(string FolderName , string FileName)
        {
            try{
                if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/Files/"+ FolderName + FileName))
                {
                    File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + FileName);
                }
               
            }
            catch (Exception ex){
            
            
            }
        
        }
    
    }
}

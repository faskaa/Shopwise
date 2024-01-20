using BackEndProject.Entities;

namespace BackEndProject.Helpers
{
    public static class FileExtension
    {
        public static async Task<string> GeneratePhoto(this IFormFile file,params string[] folders)
        {


            string folderPath = Path.Combine(folders);
            string filePath = Guid.NewGuid() + file.FileName;
            string fullPath = Path.Combine(folderPath, filePath);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }

        public static bool IsValidPhotoSize(this IFormFile file , int memoryMB)
        {
            bool result = file.Length < memoryMB;
            return result;    
        }
    }
}

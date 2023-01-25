﻿namespace eBusiness.Helpers
{
    public static class FileManager
    {

        public static string SaveFile(this IFormFile formFile,string rootpath,string folderpath)
        {
            string filename = formFile.FileName;
            filename = (filename.Length>64? filename.Substring(filename.Length-15,15): filename);
            filename = Guid.NewGuid().ToString()+filename;

            string path = Path.Combine(rootpath,folderpath,filename);

            using(FileStream fs = new FileStream(path, FileMode.Create))
            {
                formFile.CopyTo(fs);
            }

            return filename;

        }

        public static bool CheckFileLength(this IFormFile formFile , double length)
        {
            if (formFile.Length > length) return false;
            return true;
        }
        public static bool CheckFileType(this IFormFile formFile )
        {
            if (formFile.ContentType != "image/jpeg" && formFile.ContentType != "image/png") return false;
            return true;
        }

    }
}

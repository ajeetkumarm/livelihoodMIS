using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using System.Text;

/// <summary>
/// Summary description for FileUploader
/// </summary>
public class FileUploader
{
    public static string UploadFile(string xFolderPath, FileUpload fileUploadControl)
    {
        string uploadedFileName = "";
        if (fileUploadControl.PostedFile != null)
        {
            if (fileUploadControl.HasFile)
            {
                HttpPostedFile httpPostedFile = fileUploadControl.PostedFile;
                int nFileLen = httpPostedFile.ContentLength;
                if (nFileLen > 0)
                {
                    string xFileExtension = Path.GetExtension(httpPostedFile.FileName);
                    string xFileName = Path.GetFileNameWithoutExtension(httpPostedFile.FileName);
                    uploadedFileName = xFileName;
                    uploadedFileName = RemoveSpecialCharacters(uploadedFileName);
                    uploadedFileName = RemoveWildCharacter(uploadedFileName);

                    uploadedFileName = RenameFileIfExist(xFolderPath, uploadedFileName, xFileExtension);
                    httpPostedFile.SaveAs(xFolderPath + uploadedFileName);
                }
            }
        }
        return uploadedFileName;
    }


    public static string UploadFile(string xFolderPath, HttpPostedFile httpPostedFile)
    {
        string uploadedFileName = "";
        int nFileLen = httpPostedFile.ContentLength;
        if (nFileLen > 0)
        {
            string xFileExtension = Path.GetExtension(httpPostedFile.FileName);
            string xFileName = Path.GetFileNameWithoutExtension(httpPostedFile.FileName);
            uploadedFileName = xFileName;
            uploadedFileName = RemoveSpecialCharacters(uploadedFileName);
            uploadedFileName = RemoveWildCharacter(uploadedFileName);

            uploadedFileName = RenameFileIfExist(xFolderPath, uploadedFileName, xFileExtension);
            httpPostedFile.SaveAs(xFolderPath + uploadedFileName);
        }
        return uploadedFileName;
    }
    private static string RenameFileIfExist(string filePath, string fileName, string strExtention)
    {
        string newName = fileName;
        if (File.Exists(Path.Combine(filePath, fileName + strExtention)))
        {
            int n = 0;
            string plainName = fileName.Replace(strExtention, "");
            do
            {
                n++;
                newName = string.Format("{0}({1}){2}", plainName, n, strExtention);
            }
            while (File.Exists(Path.Combine(filePath, newName)));
        }
        else
        {
            newName = fileName + strExtention;
        }
        return newName;
    }
    //public static string ReplaceCharacter(string textToReplace)
    //{
    //    if (!string.IsNullOrEmpty(textToReplace))
    //    {
    //        var stringBuilder = new StringBuilder(Regex.Replace(textToReplace.Trim(), @"\s+", "-"));
    //        stringBuilder.Replace(stringBuilder.ToString(),
    //            Regex.Replace(stringBuilder.ToString(),
    //                @"[~]+|[!]+|[?]+|[']+|[\]+|[.]+|[//]+|[|]+|[:]+|[;]+|[,]+|[@]+|[#]+|[$]+|[%]+|[/^]+|[&]+|[*]+|[*]+|[(]+|[)]+|[[]+|[]]+|[{]+|[}]+|[<]+|[>]+|[""]",
    //                "-"));

    //        stringBuilder.Replace(stringBuilder.ToString(),
    //            Regex.Replace(stringBuilder.ToString(),
    //                "[-]+",
    //                "-"));

    //        return stringBuilder.Replace(stringBuilder.ToString(),
    //            Regex.Replace(stringBuilder.ToString(),
    //                @"[-]+$",
    //                "")).ToString().ToLower();
    //    }
    //    else
    //    {
    //        return textToReplace;
    //    }
    //}
    public static bool ValidateFileIsImage(FileUpload fileUploadControl)
    {
        bool retValue = true;
        if (fileUploadControl.PostedFile != null)
        {
            if (fileUploadControl.HasFile)
            {
                HttpPostedFile hpfName = fileUploadControl.PostedFile;
                string fileType = hpfName.ContentType.ToString();
                switch (fileType)
                {
                    case "image/gif":
                    case "image/png":
                    case "image/jpeg":
                    case "image/pjpeg":
                        retValue = true;
                        break;
                    default:
                        retValue = false;
                        break;
                }
            }
        }
        return retValue;
    }
    public static bool ValidateImageSize(FileUpload fileUploadControl)
    {
        // File Size Limit 5 MB
        bool retValue = true;
        if (fileUploadControl.PostedFile != null)
        {
            if (fileUploadControl.HasFile)
            {
                HttpPostedFile hpfName = fileUploadControl.PostedFile;
                int nFileLen = hpfName.ContentLength;
                if (nFileLen > 5242880)
                    retValue = false;
            }
        }
        return retValue;
    }
    public void ResizeImage(string xFolderPath, string xFileName, int imgHeight)
    {
        try
        {
            System.Drawing.Image imgInput = System.Drawing.Image.FromFile(xFolderPath + xFileName);
            //Determine image format 
            ImageFormat imageFormat = imgInput.RawFormat;
            //You may even specify a standard thumbnail size
            int imgWidth = 250 * imgInput.Width / imgInput.Height;
            string imagePreFix = imgHeight.ToString() + "X" + imgWidth.ToString() + "-";
            //create new bitmap 
            Bitmap bmpResized = new Bitmap(imgInput, imgWidth, imgHeight);
            //save bitmap to disk 
            bmpResized.Save(xFolderPath + imagePreFix + xFileName, imageFormat);
            //release used resources 
            imgInput.Dispose();
            bmpResized.Dispose();
        }
        catch
        {

        }
    }
    public static string ResizeImages(string xFolderPath, string xFileName, int imgWidth, int imgHeight)
    {
        string strImageName = string.Empty;
        try
        {
            using (System.Drawing.Image imgInput = System.Drawing.Image.FromFile(xFolderPath + xFileName))
            {
                //Determine image format 
                ImageFormat imageFormat = imgInput.RawFormat;
                //You may even specify a standard thumbnail size           
                //imgWidth = imgWidth * imgInput.Width / imgInput.Height;
                string imagePreFix = imgHeight.ToString() + "X" + imgWidth.ToString() + "-";
                //create new bitmap 
                using (Bitmap bmpResized = new Bitmap(imgInput, imgWidth, imgHeight))
                {
                    //save bitmap to disk 
                    bmpResized.Save(xFolderPath + imagePreFix + xFileName, imageFormat);
                    strImageName = imagePreFix + xFileName;
                    //release used resources 
                    bmpResized.Dispose();

                    imgInput.Dispose();
                }
            }
            //if (File.Exists(xFolderPath + xFileName))
            //{
            //    File.Delete(xFolderPath + xFileName);
            //}

        }
        catch (Exception ex)
        {

        }
        return strImageName;
    }
    public static string RemoveSpecialCharacters(string uploadedFileName)
    {
        return Regex.Replace(uploadedFileName, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
    }
    public static string RemoveWildCharacter(string uploadedFileName)
    {
        if (uploadedFileName.ToString().Length > 1)
            uploadedFileName = Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(uploadedFileName, "<", ""), ">", ""), "--", ""), "'", ""), "%", ""), ";", ""), "&", ""), "", ""), "\"\"", ""), "#", ""), "", ""), "", ""), "&quot;", ""), "`", ""), "&quot;", ""), "&lt", ""), "&gt", ""), "&#40", ""), "&#41", ""), "&#35", ""), "&#38", ""), "&apos;", ""), "\u0027", "", RegexOptions.IgnoreCase);
        return uploadedFileName;
    }
    public static void Delete(string xFolderPath, string xFileName)
    {
        var xFileFullPath = xFolderPath + xFileName;
        if (File.Exists(xFileFullPath))
        {
            File.Delete(xFileFullPath);
        }
    }

    private static string IsUniquePicture()
    {
        String allowedChars = "1234567890";
        Byte[] randomBytes = new Byte[5];
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        rng.GetBytes(randomBytes);
        char[] chars = new char[5];
        int allowedCharCount = allowedChars.Length;

        for (int i = 0; i < 5; i++)
        {
            chars[i] = allowedChars[(int)randomBytes[i] % allowedCharCount];
        }
        return new string(chars);
    }
    private static string GenerateUniqueFileName(string xFolderPath, string xFileName, string xFileExtension, int fileCount = 0)
    {
        string xFileNameToCompare = "";
        string xFileNameWithExtension = xFileName + "-" + fileCount + xFileExtension;
        if (fileCount == 0)
            xFileNameWithExtension = xFileName + xFileExtension;
        var fileEntries = Directory.GetFiles(xFolderPath, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(xFileExtension, StringComparison.OrdinalIgnoreCase));
        foreach (string fileName in fileEntries)
        {
            xFileNameToCompare = Path.GetFileName(fileName);
            if (xFileNameWithExtension == xFileNameToCompare)
            {
                fileCount += 1;
                xFileNameWithExtension = GenerateUniqueFileName(xFolderPath, xFileName, xFileExtension, fileCount);
            }
        }
        return xFileNameWithExtension;
    }
}
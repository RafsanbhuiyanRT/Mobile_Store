namespace EcommerceApp;

public static class Helper
{
    public static string FileUpload(this IWebHostEnvironment _webHostEnvironment, IFormFile? file, string path = "")
    {
        if (file is null)
        {
            return string.Empty;
        }
        var uploadPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Upload");
        if (path is not null)
        {
            uploadPath = Path.Combine(uploadPath, path);
        }
        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }
        var filePath = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
        filePath = Path.Combine(uploadPath, filePath);

        using (var fileStreem = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(fileStreem);
        }
        var contentRootPath = _webHostEnvironment.ContentRootPath;
        var relativePath = filePath.Replace(contentRootPath, "");
        return relativePath.Replace(@"\wwwroot", "").Replace(@"\", "/");
    }

}

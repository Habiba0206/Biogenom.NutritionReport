using Biogenom.NutritionReport.Application.Common.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Biogenom.NutritionReport.Infrastructure.Common.Services;

public class FileUploadService : IFileUploadService
{
    private readonly IWebHostEnvironment _env;
    private readonly IHttpContextAccessor _http;

    public FileUploadService(IWebHostEnvironment env, IHttpContextAccessor http)
    {
        _env = env;
        _http = http;
    }

    public async ValueTask<string> UploadImageAsync(IFormFile file)
    {
        var uploadsPath = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads", "supplements");
        Directory.CreateDirectory(uploadsPath);

        var fileExt = Path.GetExtension(file.FileName);
        var fileName = $"{Guid.NewGuid()}{fileExt}";
        var filePath = Path.Combine(uploadsPath, fileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        var request = _http.HttpContext?.Request;
        return $"{request?.Scheme}://{request?.Host}/uploads/supplements/{fileName}";
    }

}

using Microsoft.AspNetCore.Http;

namespace Biogenom.NutritionReport.Application.Common.Services;

public interface IFileUploadService
{
    ValueTask<string> UploadImageAsync(IFormFile file);
}

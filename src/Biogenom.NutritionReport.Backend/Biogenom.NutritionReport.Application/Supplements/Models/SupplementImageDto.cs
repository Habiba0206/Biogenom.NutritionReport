using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Biogenom.NutritionReport.Application.Supplements.Models;

public class SupplementImageDto
{
    [Required]
    public IFormFile File { get; set; } = default!;
}

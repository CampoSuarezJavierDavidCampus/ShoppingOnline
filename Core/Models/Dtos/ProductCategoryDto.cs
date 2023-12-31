using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class ProductCategoryDto{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;    
}

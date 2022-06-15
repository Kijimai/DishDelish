#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

public class Dish
{
  [Key]
  public int PostId { get; set; }

  [Required]
  [Display(Name = "Name of Dish")]
  [MinLength(2, ErrorMessage = "Description must be at least 2 characters.")]
  [MaxLength(45)]

  public string Name { get; set; }

  [Required]
  [Display(Name = "Chef's Name")]
  [MinLength(2, ErrorMessage = "Description must be at least 2 characters.")]
  [MaxLength(45)]
  public string Chef { get; set; }

  [Required]
  [Range(1, 6)]
  public int Tastiness { get; set; }

  [Required]
  [Display(Name = "# of Calories")]
  public int Calories { get; set; }

  [Required]
  [MinLength(20, ErrorMessage = "Description must be at least 20 characters.")]
  [MaxLength(200, ErrorMessage = "Description must be at under 200 characters.")]
  public string Description { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
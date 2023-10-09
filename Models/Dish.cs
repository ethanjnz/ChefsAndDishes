#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace chefsAndDishes.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters!")]
    [DisplayName("Name of Dish")]
    public string Name { get; set; }

    [Required]
    [DisplayName("# of Calories")]
    [Range(1, 50000)]
    public int Calories { get; set; }

    [Required]
    [Range(1, 5)]
    public int Tastiness { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;

    // fk
    [Required]
    [DisplayName("Chef Name")]
    public int? UserId { get; set; }

    // NAV
    public User? Creator { get; set; }
}
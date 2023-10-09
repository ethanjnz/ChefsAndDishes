#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefsAndDishes.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "First name must be at least 2 characters!")]
    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters!")]
    public string LastName { get; set; }


    [Required]
    [DataType(DataType.Date)]
    [FutureDate]
    [DisplayName("Date of Birth")]
    public DateTime Birthday { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;

    // NAV PROP
    public List<Dish> AllDishes { get; set; } = new();

}

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null || (DateTime)value > DateTime.Now)
        {
            return new ValidationResult("Birthday must be in the past");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}

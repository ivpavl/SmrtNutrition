// using System.ComponentModel.DataAnnotations;

namespace SmrtNutrition.Data;
public class MealModel
{
    // [Required]
    public int Id {get; set;}
    public string ImageUrl {get; set;} = null!;
    public string MealName {get; set;} = null!;

}

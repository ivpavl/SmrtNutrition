// using System.ComponentModel.DataAnnotations;

namespace SmrtNutrition.Data;
public class MealInfoModel
{
    // [Required]
    public int DesiredCalories {get; set;} 
    public int MaxTimeToCook {get; set;}
    public Dictionary<string, int> DesiredNutrients {get; set;} = null!;
    public Dictionary<string, bool> DishTypes {get; set;} = null!;
    
}

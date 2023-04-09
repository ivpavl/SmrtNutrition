// using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
namespace SmrtNutrition.Data;
public class MealInfoModel
{
    public int MaxTimeToCook {get; set;}
    /// <example>{"age":31,"height":234}</example>
    /// <example>{"Proteins": 50, "Fats": 50, "Carbohydrates": 50}</example>
    // [SwaggerSchema(Required = new[] {"Calories", "Proteins", "Fat", "Carbohydrates"})]
    public Dictionary<string, int> DesiredNutrients {get; set;} = null!;
    public Dictionary<string, bool> DishTypes {get; set;} = null!;

    
}

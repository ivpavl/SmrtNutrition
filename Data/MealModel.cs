// using System.ComponentModel.DataAnnotations;
// using System.Text.Json.Serialization;
namespace SmrtNutrition.Data;
public class MealModel
{
    public int Id {get; set;}
    public string ImageUrl {get; set;} = null!;
    public string Title {get; set;} = null!;
    
    public Dictionary<string, int> Nutrition {get;set;} = null!;
    public List<string> Recipy {get; set;} = null!;
    
}

public enum NutrientsNames
{
    Calories, 
    Protein,
    Fat,
    Carbohydrates,
}
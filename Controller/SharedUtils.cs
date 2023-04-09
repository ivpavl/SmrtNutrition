using SmrtNutrition.Data;
using Newtonsoft.Json.Linq;

namespace SmrtNutrition.Shared
{
    public static class SharedUtils
    {
        //Complex Search - API name in spoonacular.com
        //Complex Search Json -> List<MealModel>
        public static List<MealModel> CompSearToMealList(JObject json)
        {
            var MealList = new List<MealModel>();
            JToken results = json.GetValue("results");
            foreach(JToken dish in results)
            {
                int id = (int)dish.SelectToken("id")!;
                var nutrients = dish["nutrition"]["nutrients"]
                .Where(s => Enum.IsDefined(typeof(NutrientsNames), (string)s["name"]))
                .ToList();

                var recipeSteps = dish["analyzedInstructions"][0]["steps"];


                Dictionary<string, int> nutrDict = nutrients?
                    .Where(n => Enum.IsDefined(typeof(NutrientsNames), (string)n.SelectToken("name")!))
                    .ToDictionary(n => (string)n.SelectToken("name")!, n => (int)n.SelectToken("amount")!)!;

                List<string> recipe = recipeSteps?
                    .Select(r => (string)r.SelectToken("step")!)
                    .ToList()!;


                MealList.Add(new MealModel()
                {
                    Id = id,
                    ImageUrl = (string)dish.SelectToken("image")!,
                    Title = (string)dish.SelectToken("title")!,
                    Nutrition = nutrDict,
                    Recipy = recipe,
                });


            }
            return MealList;
        }


            public static List<MealModel> PossibleMeals(Dictionary<string, List<MealModel>> typedMeals, MealInfoModel infoModel)
            {
                var types = typedMeals.Keys.ToArray();
                return PossibleMeals(typedMeals, infoModel.DesiredNutrients, types, 0, new List<MealModel>());
            }
            private static List<MealModel> PossibleMeals(Dictionary<string, List<MealModel>> typedMeals, Dictionary<string, int> infoModel, string[] types, int typeIndex, List<MealModel> result)
            {
                if (typeIndex >= types.Count()) 
                {
                    return result;
                }
                if (typedMeals[types[typeIndex]].Count() == 0)
                {
                    return PossibleMeals(typedMeals, infoModel, types, typeIndex + 1, result);
                }
                for (int i = 0; i < typedMeals[types[typeIndex]].Count(); i++)
                {
                    MealModel currentMeal = typedMeals[types[typeIndex]][i];

                    var newInfoModel = infoModel.ToDictionary(entry => entry.Key, entry => entry.Value);

                    foreach (var item in currentMeal.Nutrition)
                        newInfoModel[item.Key] -= currentMeal.Nutrition[item.Key];
                    if(newInfoModel.Where(x => x.Value < 0 && Math.Abs(x.Value/infoModel[x.Key]) > 0.15 && Math.Abs(x.Value - infoModel[x.Key]) > 10).Count() > 1) continue;
                    if (!result.Contains(currentMeal))
                        result.Add(currentMeal);
                    return PossibleMeals(typedMeals, newInfoModel, types, typeIndex + 1, result);
                }
                return result;
            }

    }

}

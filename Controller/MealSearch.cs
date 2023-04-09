using Microsoft.AspNetCore.Mvc;
using System;
using SmrtNutrition.Data;
using Newtonsoft.Json.Linq;
using static SmrtNutrition.Shared.SharedUtils;
using System.Text;

namespace SmrtNutrition.Controllers
{
    [ApiController]
    [Route("api/food/[controller]")]
    public class MealSearchController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly HttpClient _httpClient;
         public MealSearchController(IConfiguration Configuration, HttpClient httpClient) {
            this._configuration = Configuration;
            this._httpClient = httpClient;
        }

        [HttpPost]
        public async Task<IActionResult> GetDishes([FromBody] MealInfoModel? infoModel)
        {
            string apiSearch = $"https://api.spoonacular.com/recipes/complexSearch?apiKey={_configuration["ApiKey"]}";
            var dishType = new List<string>(){"main course", "side dish", "dessert"};
            var typedMeals = new Dictionary<string, List<MealModel>>(); // Typed in the sense of typification
            var rand = new Random();
            
            foreach (string type in dishType)
            {
                int MaxRecipes = Convert.ToInt32(_configuration["MaxRecipes"]);
                int MaxOffset = Convert.ToInt32(_configuration["MaxOffset"]) - MaxRecipes - 1;
                
                StringBuilder urlBuilder = new StringBuilder(apiSearch);
                urlBuilder.Append($"&maxReadyTime={infoModel.MaxTimeToCook}");
                urlBuilder.Append($"&type={type}");
                urlBuilder.Append($"&number={_configuration["MaxRecipes"]}");
                urlBuilder.Append($"&addRecipeNutrition=true");
                urlBuilder.Append($"&offset={rand.Next(MaxOffset)}");
                string url = urlBuilder.ToString();
                
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                var responseString = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseString);
                typedMeals[type] = CompSearToMealList(json);
            }

            var possibleMeals = PossibleMeals(typedMeals, infoModel);

            return Ok(possibleMeals);

        }

    }

}

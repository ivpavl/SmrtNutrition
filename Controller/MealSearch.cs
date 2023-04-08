using Microsoft.AspNetCore.Mvc;
using System;
using SmrtNutrition.Data;
namespace SmrtNutrition.Controllers
{
    [ApiController]
    [Route("api/food/[controller]")]
    public class MealSearchController : ControllerBase
    {
        [HttpPost]
        public ActionResult<List<MealModel>> GetRecipies([FromBody] MealInfoModel? infoModel)
        {
            var possibleMeals = new List<MealModel>()
            {
                new MealModel(){Id = 25, ImageUrl = "heh", MealName = "Name1"},
                new MealModel(){Id = 25, ImageUrl = "heh", MealName = "Name2"},
                new MealModel(){Id = 25, MealName = "Name2"}
            };
            
            // Some Logic

            return Ok(new { possibleMeals });

        }

    }

}

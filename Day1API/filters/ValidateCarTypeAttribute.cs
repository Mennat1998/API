using Day1API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day1API.filters
{
    public class ValidateCarTypeAttribute :ActionFilterAttribute
    {
        // Validate Type of Car “Electric, Gas, Diesel and Hybrid”.
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //input parameter

            Car? car = context.ActionArguments["car"] as Car;

            //check validation of Type
           //" Electric|Gas|Diesel|Hybrid"

            var AllowedTypes= " Electric|Gas|Diesel|Hybrid" .Split('|');
            //short circuit with Bad Request

            if ( car is null || !AllowedTypes.Contains(car.Type) )
            {
                context.ModelState.AddModelError("Type", "Type is not Correct");
                context.Result=new BadRequestObjectResult(context.ModelState);
            }


        }
    }
}

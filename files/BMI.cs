using Microsoft.AspNetCore.Mvc;
using System;

namespace HealthMetrics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // 1. Inherit from the required base class for Web API controllers
    public class BmiController : ControllerBase
    {
        // 2. Specify the correct HTTP method attribute
        [HttpGet]
        
        // 3. Bind the incoming URL parameters to these variables
        public IActionResult CalculateBmi([FromQuery] double height, [FromQuery] double weight)
        {
            // 1. VALIDATION
            // Check if the inputs are physically impossible (zero or negative)
            if (height<=0 || weight<=0)
            {
                // 4. Return the correct HTTP 400 status method with the error message
                return BadRequest("Height and weight must be greater than zero.");
            }

            // 2. CALCULATION
            double heightInMeters = height / 100.0;
            
            // 5. Apply the standard BMI mathematical formula
            double bmi = weight / (heightInMeters * heightInMeters);
            double roundedBmi = Math.Round(bmi, 2);

            // 3. CATEGORIZATION
            // 6. Write the conditions to categorize the BMI:
            // Underweight (< 18.5), Normal (< 25), Overweight (< 30), Obese (30 or greater)
            string category = "";
            
            if (roundedBmi < 18.5)
            {
                category = "Underweight";
            }
            else if (roundedBmi < 25)
            {
                category = "Normal";
            }
            else if (roundedBmi < 30)
            {
                category = "Overweight";
            }
            else
            {
                category = "Obese";
            }

            // 4. RESPONSE
            // 7. Return the correct HTTP 200 status method containing the JSON payload
            return Ok(new 
            { 
                Bmi = roundedBmi , 
                Category = category
            });
        }
    }
}



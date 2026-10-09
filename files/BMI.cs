using Microsoft.AspNetCore.Mvc;
using System;

namespace HealthMetrics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BmiController : ControllerBase
    {
        
        [HttpGet]
        
        
        public IActionResult CalculateBmi([FromQuery] double height, [FromQuery] double weight)
        {
           
            if (height<=0 || weight<=0)
            {
                
                return BadRequest("Height and weight must be greater than zero.");
            }

           
            double heightInMeters = height / 100.0;
            
            
            double bmi = weight / (heightInMeters * heightInMeters);
            double roundedBmi = Math.Round(bmi, 2);

            
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

            
            return Ok(new 
            { 
                Bmi = roundedBmi , 
                Category = category
            });
        }
    }
}



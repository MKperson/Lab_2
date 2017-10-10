using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace AgeCalculatorV2.Pages
{
    public class AgeCalculatorModel : PageModel
    {
        AgeCalculator age = null;
        public string Date { get; set; }
        const string DATE = "Date";
        public string Result { get; set; }

        public void OnGet()
        {
            string date = DateTime.Now.ToString();
            HttpContext.Session.SetString(DATE,date);
            
        }
        public IActionResult OnPost()
        {
            Date = HttpContext.Session.GetString(DATE);
            try
            {
                
                age = new AgeCalculator(
                    int.Parse(Request.Form["Month"]), 
                    int.Parse(Request.Form["Day"]), 
                    int.Parse(Request.Form["Year"]));
                Result = age.ToString();
            }

            catch
            {
                Result = "Please only Intager Values";
            }
            return Page();
        }
    }
}
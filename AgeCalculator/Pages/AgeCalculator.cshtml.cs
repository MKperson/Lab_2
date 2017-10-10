using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgeCalculator.Pages
{
    public class AgeCalculatorModel : PageModel
    {
        public string BDay { get; set; }
        public string Date { get; set; }
        public string Result { get; set; }
        int cmonth = DateTime.Today.Month;
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            try {
                int day = int.Parse(Request.Form["Day"]);
                int month = int.Parse(Request.Form["Month"]);
                int year = int.Parse(Request.Form["Year"]);

                int yold = DateTime.Today.Year - year;
                int mold = DateTime.Today.Month - month;
                int dold = DateTime.Today.Day - day;
                

                if (dold < 0)
                {
                    if (cmonth == 1 || cmonth == 3 || cmonth == 5 || cmonth == 7 || cmonth == 10 || cmonth == 12)
                    {
                        dold = 31 + dold;
                    }
                    else
                    {
                        dold = 30 + dold;
                    }
                    mold -= 1;
                }
                if (mold < 0)
                {
                    mold = 12 + mold;
                    yold--;
                }

                if (yold < 0)
                {
                    Result = "Wow Your NOT born Yet?";
                    return Page();
                }



                Result = "You are " + yold + " Years " + mold + " Months and " + dold + " Days";

                return Page();
            }
            catch
            {
                Result = "Please Use Intager Values only ex. 1,2,3,... thank you";
                return Page();
            }

            }
    }
}
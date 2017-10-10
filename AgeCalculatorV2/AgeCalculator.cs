using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeCalculatorV2
{
    public class AgeCalculator
    {
        private int Month {get;set;}
        private int Day { get; set; }
        private int Year { get; set; }
        private string Result { get; set; }

        // Used in OnPost when retrieving saved info
        public AgeCalculator(int month,int day, int year)
        {
            Month = month;
            Day = day;
            Year = year;
        }
        public void Calculate()
        {
            int day = DateTime.Today.Date.Day;
            int month = DateTime.Today.Date.Month;
            int year  = DateTime.Today.Date.Year;

            int yold =  year-Year;
            int mold =  month-Month;
            int dold =  day-Day;


            if (dold < 0)
            {
                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 10 || month == 12)
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
            }
            else if (yold > 1000)
            {
                Result = "Are you sure you entered the year correctly? " + "You are " + yold + " Years " + mold + " Months and " + dold + " Days";
            }
            else
            Result = "You are " + yold + " Years " + mold + " Months and " + dold + " Days";




        }

        public override string ToString()
        {
            Calculate();
            return Result;
        }

    }
}

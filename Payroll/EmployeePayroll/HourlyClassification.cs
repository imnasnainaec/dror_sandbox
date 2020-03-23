using System;
using System.Collections.Generic;

namespace EmployeePayroll
{
    public class HourlyClassification : PayClassification
    {
        float payRate;
        List<TimeCard> timeCards;

        public float CalculatePay(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Friday) {
                float pay = 0;
                TimeSpan difference;
                TimeSpan oneWeek = new TimeSpan(7,0,0,0);
                foreach (TimeCard card in timeCards) {
                    difference = date.AddDays(1).Subtract(card.Date);
                    if (difference.CompareTo(oneWeek) <= 0 && difference.CompareTo(TimeSpan.Zero) == 1) {
                        pay += card.Hours;
                    }
                }
                pay *= payRate;
                return pay;
            } else {
                return 0;
            }
            //throw new NotImplementedException("Calculate pay!");
        }
    }
}
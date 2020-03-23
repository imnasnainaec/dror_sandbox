using System;

namespace EmployeePayroll
{
    public class TimeCard : DatedDocument
    {
        public TimeCard(float hours, int[] date) : base(date)
        {
            this.Hours = hours;
        }

        public float Hours
        { get; private set; }


    }
}
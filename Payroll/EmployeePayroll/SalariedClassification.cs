using System;

namespace EmployeePayroll
{
    public class SalariedClassification : PayClassification
    {
        float payRate;

        public virtual float CalculatePay(DateTime date)
        {
            if (date.Month == (date.AddDays(1).Month)) {
                return this.payRate;
            } else {
                return 0;
            }
            //throw new NotImplementedException("Calculate pay!");
        }
    }
}
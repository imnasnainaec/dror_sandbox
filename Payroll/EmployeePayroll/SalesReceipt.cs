using System;

namespace EmployeePayroll
{
    public class SalesReceipt : DatedDocument
    {
        public SalesReceipt(float amount, int[] date) : base(date)
        {
            this.Amount = amount;
        }
        
        public float Amount
        { get; private set; }

    }
}
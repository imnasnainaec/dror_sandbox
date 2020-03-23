using System;
using System.Collections.Generic;

namespace EmployeePayroll
{
    public class CommissionedClassification : SalariedClassification
    {
        float commissionRate;
        List<SalesReceipt> salesReceipts;

        public override float CalculatePay(DateTime date)
        {
            throw new NotImplementedException("Calculate pay!");
            /*if () {
                float pay = this.payRate;
                foreach (SalesReceipt receipt in salesReceipts) {
                    if (receipt.Date.Month == date.Month) {
                        pay += receipt.Amount;
                    }
                }
                return pay;
            } else {
                return 0;
            }
            */
        }

    }
}
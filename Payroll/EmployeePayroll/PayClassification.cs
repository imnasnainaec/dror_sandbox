using System;

namespace EmployeePayroll
{
    public interface PayClassification
    {
        float CalculatePay(DateTime date);
    }
}
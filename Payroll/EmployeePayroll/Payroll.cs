using System;

namespace EmployeePayroll
{
    public class Payroll
    {
        
        public Employee NewEmployee(string name, string address, char payClass, float payRate)
        {
            PayClassification payClassification;
            if (payClass == 'H') {
                payClassification = new HourlyClassification();
            } else if (payClass == 'S') {
                payClassification = new SalariedClassification();
            } else if (payClass == 'C') {
                payClassification = new CommissionedClassification();
            } else {
                throw new NotSupportedException($"Invalid payClass type: {payClass}.");
            }
            Employee employee = new Employee(name, address, payClassification);
            return employee;
        }
    }
}

using System;

namespace EmployeePayroll
{
    public class Employee
    {
        public string Name
        { get; private set; }
        public string Address
        { get; private set; }
        public PayClassification PayClass
        { get; private set; }

        public Employee(string name, string address, PayClassification payClassification)
        {
            this.Name = name;
            this.Address = address;
            this.PayClass = payClassification;
        }
    }
}

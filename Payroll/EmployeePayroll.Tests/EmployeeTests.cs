using NUnit.Framework;
using EmployeePayroll;

namespace EmployeePayroll.Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        private Employee _employee;
        private Payroll _payroll;
        
        [SetUp]
        public void Setup()
        {
            //_employee = new Employee("name", "address", 'S', 0);
            _payroll = new Payroll();
        }

        [Test]
        public void Test1()
        {
            _payroll.NewEmployee("name", "address", 'S', 0);
            Assert.Pass();
        }
    }
}
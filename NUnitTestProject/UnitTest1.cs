using NUnit.Framework;
using ADO.net;

namespace NUnitTestProject
{
    public class Tests
    {
        [Test]
        public void GivenSalary_ShouldUpdateSalaryInDatabase()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.EmpID = 3;
            model.EmpName = "Megan";
            model.BasicPay = 3000000;
            //employeeRepository.UpdateSalary(model);
            //double actual = employeeRepository.ReadSalary();
           // Assert.AreEqual(model.BasicPay, actual);
        }
    }
}
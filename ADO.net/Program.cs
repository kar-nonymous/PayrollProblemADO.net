// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kumar Kartikeya"/>
// --------------------------------------------------------------------------------------------------------------------
using System;

namespace ADO.net
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EmployeeRepository employeeRepository = new EmployeeRepository();

            ///Instance of the GetAllEmployees method
            //employeeRepository.GetAllEmployees();
            EmployeeModel model = new EmployeeModel();

            ///Adding employee deatils into the database
            model.CompanyId = 562;
            model.CompanyName = "Amazon";
            model.DeptId = 50;
            model.DeptName = "IT";
            model.DeptId = 50;
            model.EmpID = 6;
            model.EmpName = "Ruffalo";
            model.Gender = "M";
            model.PhnNo = "7894561230";
            model.Address = "Texas";
            model.StartDate = DateTime.Now;
            model.BasicPay = 852000;
            model.Deductions = 7400;
            model.TaxablePay = 8500;
            model.IncomeTax = 8900;
            model.NetPay = 9600001;
            Console.WriteLine(employeeRepository.AddDataToMultipleTables(model) ? "Record inserted successfully " : "Failed");

            ///Updating the basic pay with given name and employee id
            //model.EmpID = 3;
            //model.BasicPay = 3000000;
            //model.EmpName = "Megan";

            //employeeRepository.GetAllEmployeesFromDate();

            //employeeRepository.ImplementDatabaseFunctions();
        }
    }
}

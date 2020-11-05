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
            employeeRepository.GetAllEmployees();
            EmployeeModel model = new EmployeeModel();
            model.EmpName = "Twinkle";
            model.BasicPay = 75000;
            model.StartDate = DateTime.Now;
            model.Gender = "F";
            model.PhnNo = "7852149630";
            model.Department = "IT";
            model.Address = "Lucknow";
            model.Deductions = 4540;
            model.TaxablePay = 3204;
            model.IncomeTax = 4500;
            model.NetPay = 52000;
            Console.WriteLine(employeeRepository.AddEmployee(model) ? "Record inserted successfully " : "Failed");
        }
    }
}

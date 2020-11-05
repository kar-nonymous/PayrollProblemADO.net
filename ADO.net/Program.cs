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
        }
    }
}

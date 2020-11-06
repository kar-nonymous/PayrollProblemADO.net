// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeModel.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kumar Kartikeya"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.net
{
    public class EmployeeModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Gender { get; set; }
        public string PhnNo { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public decimal BasicPay { get; set; }
        public decimal Deductions { get; set; }
        public decimal TaxablePay { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetPay { get; set; }
    }
}

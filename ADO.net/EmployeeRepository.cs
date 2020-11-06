// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeRepository.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kumar Kartikeya"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ADO.net
{
    public class EmployeeRepository
    {
        /// <summary>
        /// UC 1:
        /// The connection string which creates the connection between our code and the databse
        /// </summary>
        public static string connectionString = "Data Source=KARTIKEYA;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection(connectionString);
        /// <summary>
        /// UC 2:
        /// Gets all the employees from the database.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void GetAllEmployees()
        {
            EmployeeModel model = new EmployeeModel();
            try
            {
                using (this.connection)
                {
                    string query = @"select * from dbo.employee_payroll";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.EmpID = reader.GetInt32(0);
                            model.EmpName = reader.GetString(1);
                            model.BasicPay = reader.GetDecimal(2);
                            model.StartDate = reader.GetDateTime(3);
                            model.Gender = reader.GetString(4);
                            model.PhnNo = reader.GetString(5);
                            model.Department = reader.GetString(6);
                            model.Address = reader.GetString(7);
                            model.Deductions = reader.GetDecimal(8);
                            model.TaxablePay = reader.GetDecimal(9);
                            model.IncomeTax = reader.GetDecimal(10);
                            model.NetPay = reader.GetDecimal(11);
                            Console.WriteLine("{0},{1}", model.EmpID, model.EmpName);
                        }
                    }
                    else
                        Console.WriteLine("No data found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// UC 2:
        /// Adds the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("dbo.SpAddEmployeeDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpName", model.EmpName);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@PhoneNo", model.PhnNo);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@IncomeTax", model.IncomeTax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// UC 3:
        /// Updates the salary in data base.
        /// </summary>
        /// <param name="model">The employee model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdateSalary(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateSalary", this.connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", model.EmpID);
                    sqlCommand.Parameters.AddWithValue("@salary", model.BasicPay);
                    sqlCommand.Parameters.AddWithValue("@name", model.EmpName);
                    connection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Reads the updated salary.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">no data found</exception>
        public decimal ReadSalary()
        {
            string connectionString1 = @"Data Source=KARTIKEYA;Initial Catalog=employee_payroll;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString1);
            decimal salary;
            EmployeeModel model = new EmployeeModel();
            SqlCommand command = new SqlCommand("Select * from employee_payroll", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                salary = model.BasicPay;
            }
            else
            {
                throw new Exception("no data found");
            }
            reader.Close();
            connection.Close();
            return salary;
        }
        /// <summary>
        /// UC 5:
        /// Gets all employees from database with given date range.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void GetAllEmployeesFromDate()
        {
            EmployeeModel model = new EmployeeModel();
            try
            {
                using (this.connection)
                {
                    string query = @"select * from employee_payroll where StartDate between cast('2020-01-01' as date) and cast(getdate() as date)";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.EmpID = reader.GetInt32(0);
                            model.EmpName = reader.GetString(1);
                            model.BasicPay = reader.GetDecimal(2);
                            model.StartDate = reader.GetDateTime(3);
                            model.Gender = reader.GetString(4);
                            model.PhnNo = reader.GetString(5);
                            model.Department = reader.GetString(6);
                            model.Address = reader.GetString(7);
                            model.Deductions = reader.GetDecimal(8);
                            model.TaxablePay = reader.GetDecimal(9);
                            model.IncomeTax = reader.GetDecimal(10);
                            model.NetPay = reader.GetDecimal(11);
                            Console.WriteLine("{0},{1}", model.EmpID, model.EmpName);
                        }
                    }
                    else
                        Console.WriteLine("No data found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// UC 6: 
        /// Implements the database functions like count, min, max, avg, and sum.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void ImplementDatabaseFunctions()
        {
            EmployeeModel model = new EmployeeModel();
            try
            {
                using (this.connection)
                {
                    string query = @"select Gender, SUM(BasicPay) as SumOfSalary, MAX(basicPay) as MaxSalary, MIN(BasicPay) as MinSalary, AVG(BasicPay) as AvgSalary, COUNT(BasicPay) as Count from dbo.employee_payroll where Gender='M' or Gender='F' group by Gender";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string Gender = reader[0].ToString();
                            double SumOfSalary = reader.GetDouble(1);
                            double MaxSalary = reader.GetDouble(2);
                            double MinSalary = reader.GetDouble(3);
                            double AvgSalary = reader.GetDouble(4);
                            int Count = reader.GetInt32(5);
                            Console.WriteLine("Gender:{0}\tCount:{1}\tMinSalary:{2}\tMaxSalary:{3}\tSumOfSalary:{4}\tAvgSalary:{5}\n", Gender, Count, MinSalary, MaxSalary, SumOfSalary, AvgSalary);
                        }
                    }
                    else
                        Console.WriteLine("No data found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// UC 7:
        /// Adds the data to multiple tables.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool AddDataToMultipleTables(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("dbo.spAddMultipleTables", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CompanyId", model.CompanyId);
                    command.Parameters.AddWithValue("@CompanyName", model.CompanyName);
                    command.Parameters.AddWithValue("@DeptId", model.DeptId);
                    command.Parameters.AddWithValue("@DeptName", model.DeptName);
                     command.Parameters.AddWithValue("@EmpId", model.EmpID);
                    command.Parameters.AddWithValue("@EmpName", model.EmpName);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@PhoneNo", model.PhnNo);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);                  
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@IncomeTax", model.IncomeTax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// UC 8:
        /// Gets the salary details from multiple tables.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void GetSalaryDetailsFromMultipleTables()
        {
            EmployeeModel model = new EmployeeModel();
            try
            {
                using (this.connection)
                {
                    string query = @"select e.EmpName ,p.BasicPay,p.Deductions,p.TaxablePay,p.IncomeTax,NetPay from employee e inner join payroll p on e.EmpId=p.EmpId";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.EmpName = reader.GetString(0);
                            model.BasicPay = reader.GetDecimal(1);
                            model.Deductions = reader.GetDecimal(2);
                            model.TaxablePay = reader.GetDecimal(3);
                            model.IncomeTax = reader.GetDecimal(4);
                            model.NetPay = reader.GetDecimal(5);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5}", model.EmpName, model.BasicPay, model.Deductions, model.TaxablePay, model.IncomeTax, model.NetPay);
                        }
                    }
                    else
                        Console.WriteLine("No data found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

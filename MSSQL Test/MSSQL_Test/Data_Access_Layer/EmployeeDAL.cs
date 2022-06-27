using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSSQL_Test.Entities;
using System.Linq;

namespace Data_Access_Layer
{
    public class EmployeeDAL : Controller //Or ControllerBase, Unsure 
    {
        #region Get Employees
        public IActionResult GetEmployees()
        {
            var dbEmployee = new MSSQL_TestContext();
            var empList = from e in dbEmployee.Employees
                          select e;

            return Ok(empList);
        }
        #endregion

        #region Search Employees by ID
        public IActionResult SearchEmployee(int id)
        {
            var dbEmployee = new MSSQL_TestContext();
            try
            {
                var searchResult = from e in dbEmployee.Employees
                                   where e.empId == id
                                   select e;
                if (searchResult != null)
                {
                    return Ok(searchResult);
                }
                else
                {
                    return BadRequest("Could not find employee with that ID");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Add an Employee
        public IActionResult CreateEmployee(string fName, string lName, int age)
        {
            var dbEmployee = new MSSQL_TestContext();

            var newEmployee = new Employee();

            newEmployee.empFirstName = fName;
            newEmployee.empLastName = lName;
            newEmployee.empAge = age;


            if (newEmployee != null)
            {
                dbEmployee.Employees.Add(newEmployee);
                dbEmployee.SaveChanges();

                return Created("", newEmployee);
            }
            else
            {
                return BadRequest("Error: Could not make new Employee");
            }
        }
        #endregion

        #region Update Employee
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var dbEmployee = new MSSQL_TestContext();
            try
            {
                var searchResult = (from e in dbEmployee.Employees
                                    where e.empId == id
                                    select e).SingleOrDefault();
                if (searchResult != null)
                {
                    searchResult.empFirstName = employee.empFirstName;
                    searchResult.empLastName = employee.empLastName;
                    searchResult.empAge = employee.empAge;

                    dbEmployee.SaveChanges();
                }
                else
                {
                    return BadRequest("Could not find employee with that ID");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Employee updated");
        }
        #endregion

        #region Delete Employee
        public IActionResult DeleteEmployee(int empID)
        {
            var dbEmployee = new MSSQL_TestContext();

            var emp = (from e in dbEmployee.Employees
                       where e.empId == empID
                       select e).SingleOrDefault();

            if (emp != null)
            {
                dbEmployee.Employees.Remove(emp);
                dbEmployee.SaveChanges();
                return Ok("Employee deleted.");
            }
            else
            {
                return BadRequest("Invalid Employee ID.");
            }
        }
        #endregion
    }
}

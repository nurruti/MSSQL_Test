/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MSSQL_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
    }
}*/

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MSSQL_Test.Models;
using System;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly MSSQL_TestContext dbEmployee = new MSSQL_TestContext();

        #region Get Employees
        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult GetEmployees()
        {
            var empList = from e in dbEmployee.Employees
                          select e;

            return Ok(empList);
        }
        #endregion

        #region Search Employees
        [HttpGet]
        [Route("SearchEmployees/{empID}")]
        public IActionResult SearchEmployee(int id)
        {
            try
            {
                var searchResult = from e in dbEmployee.Employees
                                   where e.EmpId == id
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

        #region Add Employee
        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult CreateEmployee(string fName, string lName, int age)
        {
            var newEmployee = new Employee();

            //newEmployee.EmpId = Id;
            newEmployee.EmpFirstName = fName;
            newEmployee.EmpLastName = lName;
            newEmployee.EmpAge = age;


            //Prevention of just hitting Enter over and over
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
      
        //I'm iffy about this one...
        #region Update Employee
        [HttpPut]
        [Route("UpdateEmployee/{empID}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            try
            {
               // if(id != employee.eID){
               //     return BadRequest("No employee exists by that ID")
               //}
                var searchResult = (from e in dbEmployee.Employees
                                   where e.EmpId == id
                                   select e).SingleOrDefault();
                if (searchResult != null)
                {
                    //searchResult.EmpId = employee.EmpId;
                    searchResult.EmpFirstName = employee.EmpFirstName;
                    searchResult.EmpLastName = employee.EmpLastName;
                    searchResult.EmpAge = employee.EmpAge;

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
        [HttpDelete]
        [Route("delete-employee/{empID}")]
        public IActionResult DeleteEmployee(int empID)
        {
            var emp = (from e in dbEmployee.Employees
                       where e.EmpId == empID
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
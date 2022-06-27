using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MSSQL_Test.Entities;
using System;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //private readonly MSSQL_TestContext dbEmployee = new MSSQL_TestContext();

        private Business_Logic_Layer.EmployeeBL _BL;
        public EmployeeController()
        {
            _BL = new Business_Logic_Layer.EmployeeBL();
        }

        #region Get Employees
        [HttpGet]
        [Route("")]
        public IActionResult GetEmployees()
        {
            //var empList = from e in dbEmployee.Employees
            //              select e;

            //return Ok(empList);

            return _BL.GetEmployees();
        }
        #endregion
        
        #region Search Employees
        [HttpGet]
        [Route("{empID:int}")]
        public IActionResult SearchEmployee(int id)
        {
            //try
            //{
            //    var searchResult = from e in dbEmployee.Employees
            //                       where e.empId == id
            //                       select e;
            //    if (searchResult != null)
            //    {
            //        return Ok(searchResult);
            //    }
            //    else
            //    {
            //        return BadRequest("Could not find employee with that ID");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            return _BL.SearchEmployee(id);
        }
        #endregion
        
        #region Add Employee
        [HttpPost]
        [Route("")]
        public IActionResult CreateEmployee(string fName, string lName, int age)
        {
            //var newEmployee = new Employee();

            //newEmployee.empFirstName = fName;
            //newEmployee.empLastName = lName;
            //newEmployee.empAge = age;


            //if (newEmployee != null)
            //{
            //    dbEmployee.Employees.Add(newEmployee);
            //    dbEmployee.SaveChanges();

            //    return Created("", newEmployee);
            //}
            //else
            //{
            //    return BadRequest("Error: Could not make new Employee");
            //}

            return _BL.CreateEmployee(fName, lName, age);
        }
        #endregion
      
        #region Update Employee
        [HttpPut]
        [Route("{empID:int}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            //try
            //{
            //    var searchResult = (from e in dbEmployee.Employees
            //                       where e.empId == id
            //                       select e).SingleOrDefault();
            //    if (searchResult != null)
            //    {
            //        searchResult.empFirstName = employee.empFirstName;
            //        searchResult.empLastName = employee.empLastName;
            //        searchResult.empAge = employee.empAge;

            //        dbEmployee.SaveChanges();

            //    }
            //    else
            //    {
            //        return BadRequest("Could not find employee with that ID");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            //return Ok("Employee updated");

            return _BL.UpdateEmployee(id, employee);
        }
        #endregion
        
        #region Delete Employee
        [HttpDelete]
        [Route("{empID:int}")]
        public IActionResult DeleteEmployee(int empID)
        {
            //var emp = (from e in dbEmployee.Employees
            //           where e.empId == empID
            //           select e).SingleOrDefault();

            //if (emp != null)
            //{
            //    dbEmployee.Employees.Remove(emp);
            //    dbEmployee.SaveChanges();
            //    return Ok("Employee deleted.");
            //}
            //else
            //{
            //    return BadRequest("Invalid Employee ID.");
            //}

            return _BL.DeleteEmployee(empID);
        }
        #endregion
        
    }
}
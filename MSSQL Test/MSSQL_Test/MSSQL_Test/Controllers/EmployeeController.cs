using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSSQL_Test.BL;
using MSSQL_Test.Models;
using System;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private Employee _BL;
        public EmployeeController()
        {
            _BL = new Employee();
        }

        #region Get Employees
        [HttpGet]
        [Route("")]
        public IActionResult GetEmployees() 
        {
            return Ok(_BL.GetEmployees());
        }
        #endregion
        
        #region Search Employees
        [HttpGet]
        [Route("{empID:int}")]
        public IActionResult SearchEmployee(int id) 
        {
            if (_BL.SearchEmployee(id) == null)
            {
                return BadRequest("Could not find employee with that ID");
            }
            return Ok(_BL.SearchEmployee(id)); 
        }
        #endregion
        
        #region Create Employee
        [HttpPost]
        [Route("")]
        public IActionResult CreateEmployee(EmployeeModel employeeModel) 
        {
            if (_BL.CreateEmployee(employeeModel) == false)
            {
                return BadRequest("Error: Could not make new Employee");
            }

            return Ok("Employee Created");
        }
        #endregion
      
        #region Update Employee
        [HttpPut]
        [Route("{empID:int}")]
        public IActionResult UpdateEmployee(int id, EmployeeModel employee) 
        {
            if(_BL.UpdateEmployee(id, employee) == false)
            {
                return BadRequest("Error: Could not make new Employee");
            }
            return Ok("Employee Updated"); 
        }
        #endregion
        
        #region Delete Employee
        [HttpDelete]
        [Route("{empID:int}")]
        public IActionResult DeleteEmployee(int empID) 
        {
            if(_BL.DeleteEmployee(empID) == false)
            {
                return BadRequest("Invalid Employee ID.");
            }
            return Ok("Employee has been deleted");
        }
        #endregion
    }
}
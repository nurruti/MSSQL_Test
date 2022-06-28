using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSSQL_Test.BL;
using MSSQL_Test.Models;
using System;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController
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
            return _BL.GetEmployees();
        }
        #endregion
        
        #region Search Employees
        [HttpGet]
        [Route("{empID:int}")]
        public IActionResult SearchEmployee(int id)
        {
            return _BL.SearchEmployee(id);
        }
        #endregion
        
        #region Add Employee
        [HttpPost]
        [Route("")]
        public IActionResult CreateEmployee(string fName, string lName, int age)
        {
            return _BL.CreateEmployee(fName, lName, age);
        }
        #endregion
      
        #region Update Employee
        [HttpPut]
        [Route("{empID:int}")]
        public IActionResult UpdateEmployee(int id, EmployeeModel employee)
        {
            return _BL.UpdateEmployee(id, employee);
        }
        #endregion
        
        #region Delete Employee
        [HttpDelete]
        [Route("{empID:int}")]
        public IActionResult DeleteEmployee(int empID)
        {
            return _BL.DeleteEmployee(empID);
        }
        #endregion
    }
}
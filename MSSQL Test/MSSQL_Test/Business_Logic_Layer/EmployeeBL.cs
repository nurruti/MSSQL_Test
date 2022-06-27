using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSSQL_Test.Entities;

namespace Business_Logic_Layer
{
    public class EmployeeBL
    {
        private Data_Access_Layer.EmployeeDAL _DAL;

        public EmployeeBL()
        {
            _DAL = new Data_Access_Layer.EmployeeDAL();
        }

        #region Get Employees
        public IActionResult GetEmployees()
        {
            return _DAL.GetEmployees();
        }
        #endregion

        public IActionResult SearchEmployee(int id)
        {
            return _DAL.SearchEmployee(id);
        }

        public IActionResult CreateEmployee(string fName, string lName, int age)
        {
            return _DAL.CreateEmployee(fName, lName, age);
        }

        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            return _DAL.UpdateEmployee(id, employee);
        }

        public IActionResult DeleteEmployee(int empID)
        {
            return _DAL.DeleteEmployee(empID);
        }
    }
}

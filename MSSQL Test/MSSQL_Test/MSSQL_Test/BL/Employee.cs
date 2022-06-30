using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSSQL_Test.Models;
using System.Linq;
using MSSQL_Test.DAL;
using System.Collections.Generic;

namespace MSSQL_Test.BL
{
    public class Employee :  IEmployee 
    {
        #region Get Employees
        public List<EmployeeModel> GetEmployees()
        {
            var dbEmployee = new EmployeeDBContext();
            var empList = (from e in dbEmployee.Employees
                          select e).ToList();

            return empList;
        }
        #endregion

        #region Search Employees by ID
        public EmployeeModel SearchEmployee(int id)
        {
            var dbEmployee = new EmployeeDBContext();
            var searchResult = (from e in dbEmployee.Employees
                                where e.empId == id
                                select e).SingleOrDefault(); 
            if (searchResult == null)
            {
                return (null); 
            }

            return ((EmployeeModel)searchResult); 
        }
        #endregion

        #region Create an Employee
        public EmployeeModel CreateEmployee(EmployeeModel employeeModel)
        {
            var dbEmployee = new EmployeeDBContext();

            var newEmployee = new EmployeeModel();

            if (employeeModel != null)
            {
                newEmployee.empFirstName = employeeModel.empFirstName;
                newEmployee.empLastName = employeeModel.empLastName;
                newEmployee.empAge = employeeModel.empAge;
                
                dbEmployee.Employees.Add(newEmployee);
                dbEmployee.SaveChanges();

                return newEmployee;
            }

            return null;
        }
        #endregion

        #region Update Employee
        public bool UpdateEmployee(int id, EmployeeModel employee)
        {
            var dbEmployee = new EmployeeDBContext();
                var searchResult = (from e in dbEmployee.Employees
                                    where e.empId == id
                                    select e).SingleOrDefault();
                if (searchResult == null)
                {
                    return false;
                }
                
                searchResult.empFirstName = employee.empFirstName;
                searchResult.empLastName = employee.empLastName;
                searchResult.empAge = employee.empAge;

                dbEmployee.SaveChanges();
                return true;
        }
        #endregion

        #region Delete Employee
        public bool DeleteEmployee(int id)
        {
            var dbEmployee = new EmployeeDBContext();

            //int tempInt;
            //bool isInt = int.TryParse(id, out tempInt);

            var emp = (from e in dbEmployee.Employees
                       where e.empId == id
                       select e).SingleOrDefault();

            if (emp == null)
            {
                return false;
            }
            
                dbEmployee.Employees.Remove(emp);
                dbEmployee.SaveChanges();
            return true;
        }
        #endregion
    }
}

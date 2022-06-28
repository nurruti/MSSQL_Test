using Microsoft.AspNetCore.Mvc;
using MSSQL_Test.Models;

namespace MSSQL_Test.BL
{
    public interface IEmployee
    {
        IActionResult GetEmployees();

        IActionResult SearchEmployee(int id);

        IActionResult CreateEmployee(string fName, string lName, int age);

        IActionResult UpdateEmployee(int id, EmployeeModel employee);

        IActionResult DeleteEmployee(int id);    

    }
}

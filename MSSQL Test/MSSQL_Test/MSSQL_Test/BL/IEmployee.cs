
using MSSQL_Test.Models;
using System.Collections.Generic;

namespace MSSQL_Test.BL
{
    public interface IEmployee
    {
        List<EmployeeModel> GetEmployees();

        EmployeeModel SearchEmployee(int id);

        EmployeeModel CreateEmployee(EmployeeModel employeeModel);

        bool UpdateEmployee(int id, EmployeeModel employee);

        bool DeleteEmployee(int id);    

    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace MSSQL_Test.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public int? EmpAge { get; set; }
    }
}

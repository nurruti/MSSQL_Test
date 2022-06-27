using System;
using System.Collections.Generic;

#nullable disable

namespace MSSQL_Test.Models
{
    public partial class Employee
    {
        public int empId { get; set; }
        public string empFirstName { get; set; }
        public string empLastName { get; set; }
        public int? empAge { get; set; }
    }
}

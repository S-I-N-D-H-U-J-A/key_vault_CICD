using System;
using System.Collections.Generic;

namespace DBFirstapp.data
{
    public partial class EmployeeLogin
    {
        public int Id { get; set; }
        public string? LoginId { get; set; }
        public string? Password { get; set; }
        public string? EmpoyeeName { get; set; }
        public int? DepartmentId { get; set; }
    }
}

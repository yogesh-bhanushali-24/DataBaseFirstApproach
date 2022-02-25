using System;
using System.Collections.Generic;

#nullable disable

namespace DataBaseFirstApproach.DBFA
{
    public partial class VwEmp
    {
        public int EmpId { get; set; }
        public string FName { get; set; }
        public double? Salary { get; set; }
        public DateTime? Doj { get; set; }
        public int? DeptId { get; set; }
    }
}

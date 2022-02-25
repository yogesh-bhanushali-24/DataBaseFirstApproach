using System;
using System.Collections.Generic;

#nullable disable

namespace DataBaseFirstApproach.DBFA
{
    public partial class Incentive
    {
        public int EmployeeRefId { get; set; }
        public DateTime? IncentiveDate { get; set; }
        public double? IncentiveAmount { get; set; }

        public virtual Employee EmployeeRef { get; set; }
    }
}

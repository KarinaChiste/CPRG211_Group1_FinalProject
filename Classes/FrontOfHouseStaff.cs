using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_FinalProject.Classes
{
    class FrontOfHouseStaff : Employee
    {
        public FrontOfHouseStaff(string employeeId, string employeeFirstName, string employeeLastName, string position, string salary, string startDate, string hours, string employeeType) : base(employeeId, employeeFirstName, employeeLastName, position, salary, startDate, hours, employeeType)
        {
        }
        public override string GetStaffType()
        {
            return "Front of House";
        }
    }
}

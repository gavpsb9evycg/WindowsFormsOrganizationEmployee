using System;

namespace WindowsFormsOrganizationEmployee.Items
{
    /// <summary>
    /// According to Jeffrey Richter, the FCL (Framework Class Library) type names are used throughout this code
    /// Employee item
    /// </summary>
    public struct EmployeeItem
    {
        public Int32 Id { get; set; }

        public String LastName { get; set; }

        public String Name { get; set; }

        public String MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public String PassportSeries { get; set; }

        public String PassportNumber { get; set; }

        public String Comment { get; set; }
    }
}

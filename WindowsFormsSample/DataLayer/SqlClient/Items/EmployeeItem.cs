using System;
using WindowsFormsSample.DataLayer;

namespace WindowsFormsSample.Items
{
    public struct EmployeeItem : IEmployee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string Comment { get; set; }
    }
}

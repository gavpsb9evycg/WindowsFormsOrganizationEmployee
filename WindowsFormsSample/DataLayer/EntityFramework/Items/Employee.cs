using System;
using WindowsFormsSample.DataLayer;

namespace WindowsFormsSample
{
    public partial class Employee : IEmployee
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string Comment { get; set; }

        public virtual Organization Organization { get; set; }
    }
}

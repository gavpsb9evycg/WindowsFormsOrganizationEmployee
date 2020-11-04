using System.Collections.Generic;
using WindowsFormsSample.Data;

namespace WindowsFormsSample.Models
{
    public class Organization : IOrganization
    {
        public Organization()
        {
            this.Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Inn { get; set; }

        public string LegalAddress { get; set; }

        public string PhysicalAddress { get; set; }

        public string Comment { get; set; }

        public virtual ICollection<Employee> Employee { get; }
    }
}

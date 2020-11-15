namespace Data.Models
{
    using System.Collections.Generic;

    public class Organization
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

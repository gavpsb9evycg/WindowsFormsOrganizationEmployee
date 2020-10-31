using WindowsFormsSample.DataLayer;

namespace WindowsFormsSample.Items
{
    public struct OrganizationItem : IOrganization
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Inn { get; set; }

        public string LegalAddress { get; set; }

        public string PhysicalAddress { get; set; }

        public string Comment { get; set; }
    }
}

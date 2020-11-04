namespace WindowsFormsSample.Data
{
    public interface IOrganization
    {
        int Id { get; set; }

        string Name { get; set; }

        string Inn { get; set; }

        string LegalAddress { get; set; }

        string PhysicalAddress { get; set; }

        string Comment { get; set; }
    }
}

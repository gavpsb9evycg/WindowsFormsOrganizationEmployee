namespace WindowsFormsSample
{
    public static class Consts
    {
        public const string CsvFilter = "Csv files (*.csv)|*.csv";
        public const string CsvHeader = "LastName,Name,MiddleName,DateOfBirth,PassportSeries,PassportNumber,Comment";
        public const int CsvPartCount = 7;

        // Commented because of Unit test. When Unit test run, there is the exception - ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath	error CS0103: The name 'ConfigurationManager does not exist in the current context.
        // ConfigurationManager.ConnectionStrings["OrganizationEmployee"].ConnectionString;
        public const string ConnectionString = "Data Source=.;Initial Catalog=OrganizationEmployee;Integrated Security=True"; //"Server=(localdb)\\mssqllocaldb;Database=OrganizationEmployee;Trusted_Connection=True;"
    }
}

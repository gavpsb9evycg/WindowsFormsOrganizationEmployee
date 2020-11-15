using System;

namespace Data
{
    public static class Consts
    {
        public const string ConnectionString = "Data Source=.;Initial Catalog=OrganizationEmployee;Integrated Security=True";
        public const string CsvFilter = "Csv files (*.csv)|*.csv";
        public const string CsvHeader = "LastName,Name,MiddleName,DateOfBirth,PassportSeries,PassportNumber,Comment";
        public const int CsvPartCount = 7;
    }
}

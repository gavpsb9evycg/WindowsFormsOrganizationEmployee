using System;

namespace WindowsFormsSample.Data
{
    public interface IEmployee
    {
        int Id { get; set; }

        string LastName { get; set; }

        string Name { get; set; }

        string MiddleName { get; set; }

        DateTime DateOfBirth { get; set; }

        string PassportSeries { get; set; }

        string PassportNumber { get; set; }

        string Comment { get; set; }
    }
}

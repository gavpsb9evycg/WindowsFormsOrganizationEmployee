namespace WindowsFormsSample.Tests
{
    using System.Collections.Generic;
    using Data;
    using NUnit.Framework;
    using WindowsFormsSample.Logic;

    [TestFixture]
    public class LogicLayerUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(@"..\..\..\TestData\TestEmployees.csv")]
        public void GetEmployeeListFromCsvTest(string fileName)
        {
            IEnumerable<IEmployee> employeeList = CsvImportHelper.GetEmployeeListFromCsv(fileName);
            CollectionAssert.IsNotEmpty(employeeList);
        }
    }
}
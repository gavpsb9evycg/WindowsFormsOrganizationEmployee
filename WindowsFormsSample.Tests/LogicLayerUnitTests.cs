using Data;
using NUnit.Framework;
using System.Collections.Generic;
using WindowsFormsSample.Logic;

namespace WindowsFormsSample.Tests
{
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
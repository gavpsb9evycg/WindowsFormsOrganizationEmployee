using NUnit.Framework;
using System;
using System.Collections.Generic;
using WindowsFormsSample.Items;
using WindowsFormsSample.LogicLayer;

namespace WindowsFormsSample.Tests
{
    public class LogicLayerUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(@"..\..\..\TestData\TestEmployees.csv")]
        public void GetEmployeeListFromCsvTest(String fileName)
        {
            List<EmployeeItem> employeeList = CsvImportHelper.GetEmployeeListFromCsv(fileName);
            CollectionAssert.IsNotEmpty(employeeList);
        }
    }
}
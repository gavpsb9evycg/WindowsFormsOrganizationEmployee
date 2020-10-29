using NUnit.Framework;
using System;
using System.Collections.Generic;
using WindowsFormsOrganizationEmployee.Items;
using WindowsFormsOrganizationEmployee.LogicLayer;

namespace WindowsFormsOrganizationEmployee.Tests
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
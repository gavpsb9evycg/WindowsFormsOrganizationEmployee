using NUnit.Framework;
using System;
using System.Collections.Generic;
using WindowsFormsOrganizationEmployee.DataLayer;
using WindowsFormsOrganizationEmployee.Items;

namespace WindowsFormsOrganizationEmployee.Tests
{
    public class DataLayerUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetEmployeeListFromCsvTest()
        {
            List<OrganizationItem> organizationList = OrganizationRetriever.GetOrganizationList();
            CollectionAssert.IsNotEmpty(organizationList);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void GetEmployeeListFromCsvTest(Int32 organizationId)
        {
            List<EmployeeItem> employeeList = EmployeeRetriever.GetEmployeeListFromDbByOrganizationId(organizationId);
            CollectionAssert.IsNotEmpty(employeeList);
        }
    }
}

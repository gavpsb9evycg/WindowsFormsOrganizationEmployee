namespace WindowsFormsSample.Tests
{
    using System.Collections.Generic;
    using Data;
    using Data.Models;
    using NUnit.Framework;

    [TestFixture]
    public class DataLayerUnitTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
        }

        [Test]
        public async void GetEmployeeListFromCsvTest()
        {
            IEnumerable<Organization> organizationList = await WebAPIHelper.GetOrganizations();
            CollectionAssert.IsNotEmpty(organizationList);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async void GetEmployeeListFromCsvTest(int organizationId)
        {
            IEnumerable<Employee> employeeList = await WebAPIHelper.GetEmployeesByOrganizationId(organizationId);
            CollectionAssert.IsNotEmpty(employeeList);
        }
    }
}

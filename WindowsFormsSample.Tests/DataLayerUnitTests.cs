using NUnit.Framework;
using System.Collections.Generic;
using WindowsFormsSample.DataLayer;

namespace WindowsFormsSample.Tests
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
            IEnumerable<IOrganization> organizationList = DataContext.Current.GetOrganizationList();
            CollectionAssert.IsNotEmpty(organizationList);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetEmployeeListFromCsvTest(int organizationId)
        {
            IEnumerable<IEmployee> employeeList = DataContext.Current.GetEmployeeListByOrganizationId(organizationId);
            CollectionAssert.IsNotEmpty(employeeList);
        }
    }
}

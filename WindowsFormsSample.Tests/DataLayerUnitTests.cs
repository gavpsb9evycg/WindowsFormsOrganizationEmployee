namespace WindowsFormsSample.Tests
{
    using System.Collections.Generic;
    using Data;
    using NUnit.Framework;

    [TestFixture]
    public class DataLayerUnitTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            DataContext.Current.Init(Consts.ConnectionString);
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

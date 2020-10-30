using System.Collections.Generic;

namespace WindowsFormsSample.DataLayer.SqlClient
{
    public static class SqlClientContext
    {
        public static IEnumerable<IOrganization> GetOrganizationList()
        {
            return OrganizationContext.GetOrganizationList();
        }

        public static IEnumerable<IEmployee> GetEmployeeListByOrganizationId(int organizationId)
        {
            return EmployeeContext.GetEmployeeListByOrganizationId(organizationId);
        }

        public static void ImportDataToDb(int organizationId, IEnumerable<IEmployee> employeeList)
        {
            EmployeeContext.ImportDataToDb(organizationId, employeeList);
        }
    }
}

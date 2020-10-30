using System;
using System.Collections.Generic;
using WindowsFormsSample.DataLayer.EntityFramework;
using WindowsFormsSample.DataLayer.SqlClient;

namespace WindowsFormsSample.DataLayer
{
    /// <summary>
    /// Routing data context.
    /// </summary>
    public static class DataContext
    {
        private static readonly DataType DataContextType = DataType.EntityFramework;

        public static IEnumerable<IOrganization> GetOrganizationList()
        {
            switch (DataContextType)
            {
                case DataType.SqlClient:
                    return OrganizationContext.GetOrganizationList();
                case DataType.EntityFramework:
                    return EntityContext.GetOrganizationList();
                default:
                    throw new NotImplementedException();
            }
        }

        public static IEnumerable<IEmployee> GetEmployeeListFromDbByOrganizationId(int organizationId)
        {
            switch (DataContextType)
            {
                case DataType.SqlClient:
                    return EmployeeContext.GetEmployeeListFromDbByOrganizationId(organizationId);
                case DataType.EntityFramework:
                    return EntityContext.GetEmployeeListFromDbByOrganizationId(organizationId);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

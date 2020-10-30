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
        public static DataContextType DataContextType { get; set; }

        public static IEnumerable<IOrganization> GetOrganizationList()
        {
            switch (DataContextType)
            {
                case DataContextType.SqlClient:
                    return SqlClientContext.GetOrganizationList();
                case DataContextType.EntityFrameworkCore:
                    return EntityContext.GetOrganizationList();
                default:
                    throw new NotImplementedException();
            }
        }

        public static IEnumerable<IEmployee> GetEmployeeListByOrganizationId(int organizationId)
        {
            switch (DataContextType)
            {
                case DataContextType.SqlClient:
                    return SqlClientContext.GetEmployeeListByOrganizationId(organizationId);
                case DataContextType.EntityFrameworkCore:
                    return EntityContext.GetEmployeeListByOrganizationId(organizationId);
                default:
                    throw new NotImplementedException();
            }
        }

        public static void ImportDataToDb(int organizationId, IEnumerable<IEmployee> employeeList)
        {
            switch (DataContextType)
            {
                case DataContextType.SqlClient:
                    SqlClientContext.ImportDataToDb(organizationId, employeeList);
                    break;
                case DataContextType.EntityFrameworkCore:
                    EntityContext.ImportDataToDb(organizationId, employeeList);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

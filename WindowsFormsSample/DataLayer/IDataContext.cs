using System.Collections.Generic;

namespace WindowsFormsSample.DataLayer
{
    public interface IDataContext
    {
        IEnumerable<IOrganization> GetOrganizationList();

        IEnumerable<IEmployee> GetEmployeeListByOrganizationId(int organizationId);

        void ImportDataToDb(int organizationId, IEnumerable<IEmployee> employeeList);
    }
}

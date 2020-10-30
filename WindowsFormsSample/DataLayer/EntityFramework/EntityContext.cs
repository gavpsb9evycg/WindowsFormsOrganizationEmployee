using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsSample.DataLayer.EntityFramework
{
    public class EntityContext
    {
        public static IEnumerable<IOrganization> GetOrganizationList()
        {
            using (var dbContext = new OrganizationEmployeeContext())
            {
                return dbContext.Organization.ToList();
            }
        }

        public static IEnumerable<IEmployee> GetEmployeeListFromDbByOrganizationId(int organizationId)
        {
            using (var dbContext = new OrganizationEmployeeContext())
            {
                return dbContext.Employee.Where(n => n.OrganizationId == organizationId).ToList();
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsSample.DataLayer.EntityFramework
{
    public static class EntityContext
    {
        public static IEnumerable<IOrganization> GetOrganizationList()
        {
            using (var dbContext = new OrganizationEmployeeContext())
            {
                return dbContext.Organization.ToList();
            }
        }

        public static IEnumerable<IEmployee> GetEmployeeListByOrganizationId(int organizationId)
        {
            using (var dbContext = new OrganizationEmployeeContext())
            {
                return dbContext.Employee.Where(n => n.OrganizationId == organizationId).ToList();
            }
        }

        public static void ImportDataToDb(int organizationId, IEnumerable<IEmployee> employeeList)
        {
            using (var dbContext = new OrganizationEmployeeContext())
            {
                foreach (IEmployee employee in employeeList)
                {
                    var newEmployee = new Employee
                    {
                        OrganizationId = organizationId,
                        LastName = employee.LastName,
                        Name = employee.Name,
                        MiddleName = employee.MiddleName,
                        DateOfBirth = employee.DateOfBirth,
                        PassportSeries = employee.PassportSeries,
                        PassportNumber = employee.PassportNumber,
                        Comment = employee.Comment
                    };

                    dbContext.Employee.Add(newEmployee);
                }

                dbContext.SaveChanges();
            }
        }
    }
}

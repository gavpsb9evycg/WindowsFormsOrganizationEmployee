namespace Data.EntityFramework
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;

    /// <summary>
    /// Entity Framework Core context.
    /// </summary>
    public class EntityContext : IDataContext
    {
        public IEnumerable<IOrganization> GetOrganizationList()
        {
            using (var context = new OrganizationEmployeeContext())
            {
                return context.Organization.ToList();
            }
        }

        public IEnumerable<IEmployee> GetEmployeeListByOrganizationId(int organizationId)
        {
            using (var context = new OrganizationEmployeeContext())
            {
                return context.Employee.Where(n => n.OrganizationId == organizationId).ToList();
            }
        }

        public void ImportDataToDb(int organizationId, IEnumerable<IEmployee> employeeList)
        {
            using (var context = new OrganizationEmployeeContext())
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
                        Comment = employee.Comment,
                    };

                    context.Employee.Add(newEmployee);
                }

                context.SaveChanges();
            }
        }
    }
}

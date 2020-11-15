namespace Data.EntityFramework
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;

    /// <summary>
    /// Entity Framework Core Helper.
    /// </summary>
    public class EntityHelper
    {
        public IEnumerable<Organization> GetOrganizationList()
        {
            using (var context = new OrganizationEmployeeContext())
            {
                return context.Organization.ToList();
            }
        }

        public IEnumerable<Employee> GetEmployeeListByOrganizationId(int organizationId)
        {
            using (var context = new OrganizationEmployeeContext())
            {
                return context.Employee.Where(n => n.OrganizationId == organizationId).ToList();
            }
        }

        public void ImportDataToDb(int organizationId, IEnumerable<Employee> employeeList)
        {
            using (var context = new OrganizationEmployeeContext())
            {
                foreach (Employee employee in employeeList)
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

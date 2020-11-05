namespace WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.EntityFramework;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly OrganizationEmployeeContext context;

        public EmployeesController(OrganizationEmployeeContext context)
        {
            this.context = context;
        }

        // GET: Employees/GetEmployeeListByOrganizationId/5
        [HttpGet("GetEmployeeListByOrganizationId/{organizationId}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeListByOrganizationId(int organizationId)
        {
            return await this.context.Employee.Where(n => n.OrganizationId == organizationId).ToListAsync();
        }

        // POST: Employees/ImportDataToDb/5
        [HttpPost("ImportDataToDb/{organizationId}")]
        public void ImportDataToDb(int organizationId, IEnumerable<IEmployee> employeeList)
        {
            //DataContext.Current.ImportDataToDb(organizationId, employeeList);
        }
    }
}

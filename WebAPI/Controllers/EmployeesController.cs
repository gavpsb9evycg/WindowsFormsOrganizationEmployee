namespace WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.EntityFramework;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly OrganizationEmployeeContext context;
        private readonly ILogger<OrganizationsController> logger;

        public EmployeesController(OrganizationEmployeeContext context, ILogger<OrganizationsController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        // GET: Employees/GetEmployeeListByOrganizationId/5
        [HttpGet("GetEmployeeListByOrganizationId/{organizationId}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeListByOrganizationId(int organizationId)
        {
            return await this.context.Employee.Where(n => n.OrganizationId == organizationId).ToListAsync();
        }

        // GET: Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await this.context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            this.context.Entry(employee).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.IsEmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: Employees/ImportDataToDb/5
        [HttpPost("ImportDataToDb/{organizationId}")]
        public async Task<IActionResult> ImportDataToDb(int organizationId, IEnumerable<Employee> employeeList)
        {
            foreach (Employee employee in employeeList)
            {
                employee.Id = 0;
                employee.OrganizationId = organizationId;
                this.context.Employee.Add(employee);
            }

            await this.context.SaveChangesAsync();
            return NoContent();
        }

        // POST: Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            this.context.Employee.Add(employee);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        // DELETE: Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await this.context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            this.context.Employee.Remove(employee);
            await this.context.SaveChangesAsync();

            return employee;
        }

        private bool IsEmployeeExists(int id)
        {
            return this.context.Employee.Any(e => e.Id == id);
        }
    }
}

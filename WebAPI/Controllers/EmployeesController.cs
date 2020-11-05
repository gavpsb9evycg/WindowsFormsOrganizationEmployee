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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeListByOrganizationId()
        {
            return await this.context.Employee.ToListAsync();
        }

        // GET: Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await this.context.Employee.ToListAsync();
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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
                if (!IsEmployeeExists(id))
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

        // POST: Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            this.context.Employee.Add(employee);
            await this.context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
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

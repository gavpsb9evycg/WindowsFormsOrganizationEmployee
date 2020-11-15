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
    public class OrganizationsController : ControllerBase
    {
        private readonly OrganizationEmployeeContext context;
        private readonly ILogger<OrganizationsController> logger;

        public OrganizationsController(OrganizationEmployeeContext context, ILogger<OrganizationsController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        // GET: Organizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organization>>> GetOrganizations()
        {
            return await this.context.Organization.ToListAsync();
        }

        /// <summary>
        /// Get employees by organization id.
        /// </summary>
        /// <param name="id">Organization id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        // GET: Organizations/5/Employees
        [HttpGet("{id}/Employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetOrganizationsIdEmployees(int id)
        {
            return await this.context.Employee.Where(n => n.OrganizationId == id).ToListAsync();
        }

        /// <summary>
        /// Import employees by organization id.
        /// </summary>
        /// <param name="id">Organization id.</param>
        /// <param name="employeeList">Employee list.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        // POST: Organizations/5/Employees
        [HttpPost("{id}/Employees")]
        public async Task<IActionResult> PostOrganizationsIdEmployees(int id, IEnumerable<Employee> employeeList)
        {
            foreach (Employee employee in employeeList)
            {
                employee.Id = 0;
                employee.OrganizationId = id;
                this.context.Employee.Add(employee);
            }

            await this.context.SaveChangesAsync();
            return NoContent();
        }

        // GET: Organizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganizationsId(int id)
        {
            var organization = await this.context.Organization.FindAsync(id);

            if (organization == null)
            {
                return NotFound();
            }

            return organization;
        }

        // PUT: Organizations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationsId(int id, Organization organization)
        {
            if (id != organization.Id)
            {
                return BadRequest();
            }

            this.context.Entry(organization).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.IsOrganizationExists(id))
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

        // POST: Organizations
        [HttpPost]
        public async Task<ActionResult<Organization>> PostOrganizations(Organization organization)
        {
            this.context.Organization.Add(organization);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(GetOrganizationsId), new { id = organization.Id }, organization);
        }

        // DELETE: Organizations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Organization>> DeleteOrganizationsId(int id)
        {
            var organization = await this.context.Organization.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }

            this.context.Organization.Remove(organization);
            await this.context.SaveChangesAsync();

            return organization;
        }

        private bool IsOrganizationExists(int id)
        {
            return this.context.Organization.Any(e => e.Id == id);
        }
    }
}

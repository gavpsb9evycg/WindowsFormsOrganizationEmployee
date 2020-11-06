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
        public async Task<ActionResult<IEnumerable<Organization>>> GetOrganizationList()
        {
            return await this.context.Organization.ToListAsync();
        }

        // GET: Organizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganization(int id)
        {
            var organization = await this.context.Organization.FindAsync(id);

            if (organization == null)
            {
                return NotFound();
            }

            return organization;
        }

        // PUT: Organizations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganization(int id, Organization organization)
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Organization>> PostOrganization(Organization organization)
        {
            this.context.Organization.Add(organization);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(GetOrganization), new { id = organization.Id }, organization);
        }

        // DELETE: Organizations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Organization>> DeleteOrganization(int id)
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

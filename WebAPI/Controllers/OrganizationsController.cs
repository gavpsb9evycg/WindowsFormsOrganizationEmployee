namespace WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.EntityFramework;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly OrganizationEmployeeContext context;

        public OrganizationsController(OrganizationEmployeeContext context)
        {
            this.context = context;
        }

        // GET: Organizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organization>>> GetOrganizationList()
        {
            return await this.context.Organization.ToListAsync();
        }
    }
}

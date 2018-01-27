using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessHub.Models;
using ProcessHub.Persistence;

namespace ProcessHub.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ProcessHubDbContext context;
        public ProjectsController(ProcessHubDbContext context)
        {
            this.context = context;
        }

        [HttpGet("/api/projects")]
        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await context.Projects.Include(p => p.WorkItems).ToListAsync();
        }
    }
}
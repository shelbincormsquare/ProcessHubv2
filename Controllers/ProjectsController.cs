using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessHub.Models;
using ProcessHub.Persistence;
using ProcessHub_Angular.Controllers.Resources;

namespace ProcessHub.Controllers
 {
    [Route ("/api/projects")]
    public class ProjectsController : Controller 
    {
        private readonly ProcessHubDbContext context;
        private readonly IMapper mapper;
        public ProjectsController (ProcessHubDbContext context, IMapper mapper) 
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectResource>> GetProjects () 
        {
            var projects = await context.Projects.Include (p => p.WorkItems).ToListAsync ();
            return mapper.Map<List<Project>, List<ProjectResource>>(projects);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject ([FromBody] ProjectResource projectResource) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var project = mapper.Map<ProjectResource, Project>(projectResource);
            context.Projects.Add(project);
            await context.SaveChangesAsync();

            var result = mapper.Map<Project, ProjectResource>(project);
            return Ok (result);
        }

            [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject (int id, [FromBody] ProjectResource projectResource) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var project = await context.Projects.FindAsync(id);
             mapper.Map<ProjectResource, Project>(projectResource, project);
           
            await context.SaveChangesAsync();

            var result = mapper.Map<Project, ProjectResource>(project);
            return Ok (result);
        }
    }
}
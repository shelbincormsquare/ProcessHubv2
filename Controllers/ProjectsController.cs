using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessHub.Controllers.Resources;
using ProcessHub.Core;
using ProcessHub.Core.Models;
using ProcessHub.Core.Repositories;
using ProcessHub.Persistence;

namespace ProcessHub.Controllers {
    [Route ("/api/projects")]
    public class ProjectsController : Controller {
        private readonly IMapper mapper;
        private readonly IProjectRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public ProjectsController (IMapper mapper, IProjectRepository repository, IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ProjectResource>> GetProjects () {
            var projects = await repository.GetProjects();
            return mapper.Map<List<Project>, List<ProjectResource>> (projects);
        }

        // [HttpPost]
        // public async Task<IActionResult> CreateProject ([FromBody] ProjectResource projectResource) {
        //     if (!ModelState.IsValid)
        //         return BadRequest (ModelState);

        //     var project = mapper.Map<ProjectResource, Project> (projectResource);
        //     context.Projects.Add (project);
        //     await context.SaveChangesAsync ();

        //     var result = mapper.Map<Project, ProjectResource> (project);
        //     return Ok (result);

        // }

        // [HttpPut ("{id}")]
        // public async Task<IActionResult> UpdateProject (int id, [FromBody] ProjectResource projectResource) {
        //     if (!ModelState.IsValid)
        //         return BadRequest (ModelState);

        //     var project = await context.Projects.FindAsync (id);
        //     mapper.Map<ProjectResource, Project> (projectResource, project);

        //     await context.SaveChangesAsync ();

        //     var result = mapper.Map<Project, ProjectResource> (project);
        //     return Ok (result);
        // }
    }
}
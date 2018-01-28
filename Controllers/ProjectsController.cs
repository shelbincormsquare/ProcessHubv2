using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProcessHub.Core;
using ProcessHub.Core.Models;
using ProcessHub.Core.Repositories;
using ProcessHub.Core.Resources;

namespace ProcessHub.Controllers
{
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
            var projects = await repository.GetProjects ();
            return mapper.Map<List<Project>, List<ProjectResource>> (projects);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetProject (int id) {
            var project = await repository.GetProject (id);

            if (project == null)
                return NotFound ();

            var projectResource = mapper.Map<Project, ProjectResource> (project);

            return Ok (projectResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject ([FromBody] ProjectResource projectResource) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            var project = mapper.Map<ProjectResource, Project> (projectResource);

            repository.Add (project);
            await unitOfWork.CompleteAsync ();

            project = await repository.GetProject (project.Id);

            var result = mapper.Map<Project, ProjectResource> (project);

            return Ok (result);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateProject (int id, [FromBody] ProjectResource projectResource) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            var project = await repository.GetProject (id);

            if (project == null)
                return NotFound ();

            mapper.Map<ProjectResource, Project> (projectResource, project);

            await unitOfWork.CompleteAsync ();

            project = await repository.GetProject (project.Id);
            var result = mapper.Map<Project, ProjectResource> (project);

            return Ok (result);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteProject (int id) {
            var project = await repository.GetProject (id);

            if (project == null)
                return NotFound ();

            repository.Remove (project);
            await unitOfWork.CompleteAsync ();

            return Ok (id);
        }
    }
}
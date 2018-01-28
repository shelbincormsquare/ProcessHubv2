using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProcessHub.Core.Models;
using ProcessHub.Core.Repositories;

namespace ProcessHub.Persistence.Repositories {
    public class ProjectRepository : IProjectRepository {
        private readonly ProcessHubDbContext context;
        public ProjectRepository (ProcessHubDbContext context) {
            this.context = context;

        }
        public void Add (Project project) {
            context.Projects.Add (project);
        }

        public async Task<Project> GetProject (int id) {
            return await context.Projects.FindAsync (id);
        }

        public async Task<List<Project>> GetProjects () {
            return await context.Projects.ToListAsync ();
        }

        public void Remove (Project project) {
            context.Remove (project);
        }

    }
}
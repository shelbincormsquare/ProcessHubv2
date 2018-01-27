using System.Threading.Tasks;
using ProcessHub.Core.Models;
using ProcessHub.Core.Repositories;

namespace ProcessHub.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public void Add(Project project)
        {
            throw new System.NotImplementedException();
        }

        public Task<Project> GetProject(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Project> GetProjects()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Project project)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Project project)
        {
            throw new System.NotImplementedException();
        }
    }
}
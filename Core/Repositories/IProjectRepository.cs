using System.Threading.Tasks;
using ProcessHub.Core.Models;

namespace ProcessHub.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> GetProject(int id); 
        void Add(Project project);
        void Remove(Project project);
        void Update(Project project);
        Task<Project> GetProjects();
    }
}
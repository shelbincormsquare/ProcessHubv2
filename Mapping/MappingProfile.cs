using AutoMapper;
using ProcessHub.Models;
using ProcessHub_Angular.Controllers.Resources;

namespace ProcessHub_Angular.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Project, ProjectResource>();
            CreateMap<WorkItem, WorkItemResource>();

            // API Resource to Domain
             CreateMap<ProjectResource, Project>()
             .ForMember(p => p.Id, opt => opt.Ignore());
             CreateMap<WorkItemResource, WorkItem>();
        }
    }
}
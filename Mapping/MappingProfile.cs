using AutoMapper;
using ProcessHub.Core.Models;
using ProcessHub.Controllers.Resources;

namespace ProcessHub.Mapping
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
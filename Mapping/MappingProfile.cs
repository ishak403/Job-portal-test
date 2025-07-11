using AutoMapper;
using TeknorixTest.Dtos;
using TeknorixTest.Entities;
using TeknorixTest.Models;

namespace TeknorixTest.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            CreateMap<Location, LocationDto>()
               .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<LocationDto, Location>()
               .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Department, DepartmentDto>()
               .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<DepartmentDto, Department>()
             .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateJobDto, Job>()
              .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Job, CreateJobDto>()
             .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Job, JobDto>()
             .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }


    }
}

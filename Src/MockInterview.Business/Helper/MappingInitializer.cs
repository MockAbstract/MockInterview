using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Models.ClientDTO;
using MockInterview.Domain.Models.EmployeeDTO;

namespace MockInterview.Business.Helper
{
    public class MappingInitializer : Profile
    {
        public MappingInitializer()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            CreateMap<Client, ClientDTO>().ReverseMap();
        }
    }
}

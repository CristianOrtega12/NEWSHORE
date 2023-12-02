using Application.DTOs.Role;
using Application.DTOs.User;
using Application.DTOs.Journey;
using AutoMapper;
using Domain.Models;
using Application.DTOs.Flight;
using Application.DTOs.Transport;

namespace Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            //CreateMap<OvertimePeriod, UploadOvertimesPeriodCommand>();
            CreateMap<User, UserDto>();
            CreateMap<User, UserPostDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<Journey, JourneyDto>();
            CreateMap<Fligth, FlightDto>();
            CreateMap<Transport, TransportDto>();
        }
    }
}

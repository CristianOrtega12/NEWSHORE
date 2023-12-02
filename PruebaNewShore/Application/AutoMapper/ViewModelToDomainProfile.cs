using Application.DTOs.Flight;
using Application.DTOs.Journey;
using Application.DTOs.Role;
using Application.DTOs.Transport;
using Application.DTOs.User;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper
{
    public class  ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            //CreateMap<UploadOvertimesPeriodCommand, OvertimePeriod>();
            CreateMap<UserDto, User>();
            CreateMap<UserPostDto, User>();
            CreateMap<RoleDto, Role>();
            CreateMap<JourneyDto , Journey>();
            CreateMap<FlightDto , Fligth>();
            CreateMap<TransportDto, Transport>();
        }
    }
}

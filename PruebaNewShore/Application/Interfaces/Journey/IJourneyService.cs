using Application.Common.Response;
using Application.Cqrs.User.Commands;
using Application.DTOs.Journey;
using Application.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Journey
{
    public interface IJourneyService
    {
        Task<ApiResponse<JourneyDto>> AddJourney(PostUserCommand request);
        Task<ApiResponse<List<JourneyDto>>> GetJourney();
    }
}
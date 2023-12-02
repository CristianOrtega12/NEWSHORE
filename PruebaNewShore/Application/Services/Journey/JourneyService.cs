using Application.Common.Response;
using Application.Cqrs.Journey.Commands;
using Application.DTOs.Journey;
using Application.Interfaces.Journey;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Journey
{
    public class JourneytService : IJourneyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;
        public JourneytService(IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
        }

        public async Task<ApiResponse<List<JourneyDto>>> GetJourney(GetJourneyQuery request)
        {
            var response = new ApiResponse<List<JourneyDto>>();

            try
            {
                response.Data = _autoMapper.Map<List<JourneyDto>>(await _unitOfWork.JourneyRepository.Get().Where(x=> x.Origin== request.JourneyDto.Origin && x.Destination == request.JourneyDto.Destination).ToListAsync());
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<JourneyDto>> AddJourney(PostJourneyCommand request)
        {
            var response = new ApiResponse<JourneyDto>();

            try
            {
                var ExitsUser = await _unitOfWork.JourneyRepository.Get()
                                                                .Where(x => x.Origin == request.JourneyDto.Origin && x.Destination == request.JourneyDto.Destination)
                                                                .FirstOrDefaultAsync();
                if (ExitsUser != null)
                {
                    return response;
                }
                Domain.Models.Journey journey = _autoMapper.Map<Domain.Models.Journey>(request.JourneyDto);

                response.Data = _autoMapper.Map<JourneyDto>(await _unitOfWork.JourneyRepository.Add(journey));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al Crear Journey. { ex.Message } ";
            }
            return response;
        }
    }
}

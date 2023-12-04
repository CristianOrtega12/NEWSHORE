using Application.Common.Response;
using Application.Cqrs.Journey.Commands;
using Application.DTOs.Flight;
using Application.DTOs.Journey;
using Application.DTOs.Transport;
using Application.Interfaces.Journey;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
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
                //var ExitJourney = await _unitOfWork.JourneyRepository.Get()
                //                                             .Where(x => x.Origin.Equals(request.Origin) && x.Destination.Equals(request.Destination))
                //                                               .ToListAsync();
                //if (ExitJourney!=null && ExitJourney.Count>0)
                //{

                //    foreach (var itemJourney in ExitJourney)
                //    {
                //        var ExitJourneyFlight = await _unitOfWork.JourneyFlightRepository.Get()
                //                                             .Where(x=> x.JourneyId == itemJourney.Id)
                //                                               .ToListAsync();
                //        foreach (var itemFlight in ExitJourneyFlight)
                //        {
                //            var Flight = await _unitOfWork.FlightRepository.Get()
                //                                             .Where(x => x.Id == itemFlight.FlightId)
                //                                               .ToListAsync();
                //            foreach (var item in Flight)
                //            {
                //                var Trasport = await _unitOfWork.TransportRepository.Get()
                //                                             .Where(x => x.Id == item.TransportId)
                //                                               .ToListAsync();
                //            }
                //        }
                //    }
                //}
                if (false)
                {

                }
                else
                {
                    var client = new HttpClient();
                    var responseApi = await client.GetAsync("https://recruiting-api.newshore.es/api/flights/1");
                    var content = await responseApi.Content.ReadAsStringAsync();
                    var responseApiSerial = JsonConvert.DeserializeObject<List<FlightApiDto>>(content);
                    //JourneyDto jresponse = new JourneyDto();
                    List<FlightDto> jflight = new List<FlightDto>();
                    foreach (var item in responseApiSerial)
                    {
                        jflight.Add(new FlightDto { Transport = new TransportDto { FligthCarrier = item.FlightCarrier, FligthCarrierNumber = item.FlightNumber }, Origin = item.DepartureStation, Destination = item.ArrivalStation, Price = item.Price });

                    }
                    List<JourneyDto> jresponses = new List<JourneyDto>();
                    jresponses = FindAllPaths(jflight, request.Origin, request.Destination);

                    foreach (var item in jresponses)
                    {
                        Domain.Models.Journey journeySave = new Domain.Models.Journey {Origin=item.Origin,Destination=item.Destination,Price=item.Price };
                        var idjourney= await _unitOfWork.JourneyRepository.Add(journeySave);
                        foreach (var itemFlight in item.Flights)
                        {
                            Fligth flightSave = new Fligth {Origin=itemFlight.Origin,Destination=itemFlight.Destination,Price=itemFlight.Price };
                            Transport trasportSave = new Transport {FligthCarrier=itemFlight.Transport.FligthCarrier,FligthCarrierNumber=itemFlight.Transport.FligthCarrierNumber };
                            var idtrasportSave = await _unitOfWork.TransportRepository.Add(trasportSave);
                            flightSave.TransportId = idtrasportSave.Id;
                            JourneyFlight journeyFlihgtSave = new JourneyFlight {JourneyId=idjourney.Id};
                            var idFlight= await _unitOfWork.FlightRepository.Add(flightSave);
                            journeyFlihgtSave.FlightId = idFlight.Id;
                            await _unitOfWork.JourneyFlightRepository.Add(journeyFlihgtSave);
                        }
                    }
                    response.Data = jresponses;
                }
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }
        // Función para encontrar todas las rutas desde un origen a un destino
        public static List<JourneyDto> FindAllPaths(List<FlightDto> routes, string start, string target)
        {
            // Lista de rutas encontradas
            List<JourneyDto> paths = new List<JourneyDto>();
            // Bucle principal
            for (int i = 0; i < routes.Count; i++)
            {
                // Si la ruta actual comienza en el nodo de origen
                if (routes[i].Origin == start)
                {
                    // Si el destino de la ruta actual es el destino deseado
                    if (routes[i].Destination == target)
                    {
                        // Agregar la ruta a la lista de rutas encontradas
                        JourneyDto journey= new JourneyDto { Origin = start, Destination = target, Price = routes[i].Price };
                        journey.Flights = new List<FlightDto>{routes[i]};
                        paths.Add(journey);
                    }
                    else
                    {
                        // Buscar una ruta que comience en el nodo de destino de la ruta actual
                        List<JourneyDto> nextPath = FindAllPaths(routes, routes[i].Destination, target);

                        // Si se encuentra una ruta
                        if (nextPath != null && nextPath.Count>0)
                        {
                            // Combinar las dos rutas
                            JourneyDto path = new JourneyDto { Origin=routes[i].Origin,Destination= target,Price= routes[i].Price + nextPath.Sum(x => x.Price) };
                            path.Flights = new List<FlightDto> { routes[i] };
                            path.Flights.AddRange(nextPath.SelectMany(x => x.Flights));
                            // Agregar la ruta a la lista de rutas encontradas
                            paths.Add(path);
                        }
                    }
                }
            }
            // Devolver la lista de rutas encontradas
            return paths;
        }

        // Ejemplo de uso
        
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

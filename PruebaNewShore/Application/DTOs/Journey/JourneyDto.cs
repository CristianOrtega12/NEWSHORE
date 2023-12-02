using Application.DTOs.Flight;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Journey
{
    public class JourneyDto
    {
        public List<FlightDto> Flights { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
    }
}

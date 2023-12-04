using Application.DTOs.Transport;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Flight
{
    public class FlightApiDto
    {
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public string FlightCarrier { get; set; }
        public string FlightNumber { get; set; }
        public double Price { get; set; }
    }
}

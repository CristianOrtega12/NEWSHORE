using Application.DTOs.Transport;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Flight
{
    public class FlightDto
    {
        public TransportDto Transport { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
    }
}

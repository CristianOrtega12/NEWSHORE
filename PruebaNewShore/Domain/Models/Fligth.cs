using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Fligth : Entity
    {
        public Transport Transport { get; set; }
        public string Origin { get; set; }
        public bool Destination { get; set; }
        public double Price { get; set; }
    }
}

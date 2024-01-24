using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Journey : Entity
    {
            public string Origin { get; set; }
            public string Destination { get; set; }
            public double Price { get; set; }
            public virtual ICollection<JourneyFlight> JourneyFlights { get; set; }

    }
}

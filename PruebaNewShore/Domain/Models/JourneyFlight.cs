using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class JourneyFlight : Entity
    {
            public int FlightsId { get; set; }
            [ForeignKey("FlightsId")]
            public Fligth Fligth { get; set; }
            public int JourneyId { get; set; }
            [ForeignKey("JourneyId")]
            public Journey Journey { get; set; }
    }
}

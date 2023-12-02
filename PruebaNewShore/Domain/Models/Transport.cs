using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Transport : Entity
    {
        public string FligthCarrier { get; set; }
        public string FligthCarrierNumber { get; set; }
    }
}

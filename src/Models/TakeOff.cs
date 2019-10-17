using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRunwayApi.Models
{
    public class TakeOff : Resource
    {
        public int Id { get; set; }

        public int RunwayId { get; set; }

        public int FlightId { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public bool IsFinished { get; set; }
    }
}

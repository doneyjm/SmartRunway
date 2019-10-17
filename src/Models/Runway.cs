using System;
using System.Collections.Generic;

namespace SmartRunwayApi.Models
{
    public class Runway : Resource
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public DateTimeOffset NextAvailableTime { get; set; }

        public ICollection<Landing> Landings { get; set; }

        public ICollection<TakeOff> TakeOffs { get; set; }
    }
}
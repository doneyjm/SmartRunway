using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRunwayApi.Models
{
    public class Flight : Resource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan LandingDuration { get; set; }

        public TimeSpan TakeOffDuration { get; set; }
    }
}

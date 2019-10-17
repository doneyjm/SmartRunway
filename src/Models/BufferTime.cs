using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRunwayApi.Models
{
    public class BufferTime
    {
        /// <summary>
        /// Buffer time in minutes
        /// </summary>
        public int? LandingBuffer { get; set; }

        /// <summary>
        /// Buffer time in minutes
        /// </summary>
        public int? TakeOffBuffer { get; set; }
    }
}

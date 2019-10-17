using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartRunwayApi.Data.Entities
{
    public class TakeOff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RunwayId { get; set; }

        public int FlightId { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public bool IsFinished { get; set; }
    }
}
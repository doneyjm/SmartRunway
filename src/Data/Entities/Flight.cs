using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartRunwayApi.Data.Entities
{
    public class Flight
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan LandingDuration { get; set; }

        public TimeSpan TakeOffDuration { get; set; }
    }
}
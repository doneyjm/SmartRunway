using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartRunwayApi.Data.Entities
{
    public class Runway
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset NextAvailableTime { get; set; }

        public ICollection<Landing> Landings { get; set; }

        public ICollection<TakeOff> TakeOffs { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixTelematics.Models
{
    public class VehicleData
    {
            public int PositionId { get; set; }
            public string VehicleRegistration { get; set; }
            public float Latitude { get; set; }
            public float Longitude { get; set; }
            public DateTime RecordedTimeUTC { get; set; }
      
    }
}

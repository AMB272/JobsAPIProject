using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPIProject.Entities.LocationEntities
{
    public class LocationsResponse
    {
        public List<LocationEntity>? LstLocations { get; set; }
    }

    public class LocationEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int? Zip { get; set; }
    }
}
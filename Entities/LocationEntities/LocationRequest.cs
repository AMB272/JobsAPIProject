using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPIProject.Entities.LocationEntities
{
    public class LocationRequest
    {
    public string? LocationTitle { get; set; }
    public string? LocationCity { get; set; }
    public string? LocationState { get; set; }
    public string? LocationCountry { get; set; }
    public int? LocationZip { get; set; }
    }
}
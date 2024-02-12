using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsAPIProject.Entities.LocationEntities;
using JobsAPIProject.Models;
using JobsAPIProject.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace JobsAPIProject.Repository
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly JobsDbContext context;

        public LocationsRepository(JobsDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await context.Locations.ToListAsync();
        }

        public async Task<LocationEntity> InsertLocation(LocationEntity location)
        {
            var newLocation = new Location
            {
                LocationTitle = location.Title ?? "",
                LocationCity = location.City ?? "",
                LocationState = location.State ?? "",
                LocationCountry = location.Country ?? "",
                LocationZip = location.Zip ?? 0
            };
            await context.Locations.AddAsync(newLocation);
            await context.SaveChangesAsync();
            return location;
        }

        public async Task<LocationEntity> UpdateLocation(int id, LocationEntity locationChanges)
        {
            var locationRecord = await context.Locations.Where(x => x.LocationId == id).FirstOrDefaultAsync();
            if (locationRecord != null)
            {
                if (locationChanges.Title != locationRecord.LocationTitle){
                    locationRecord.LocationTitle = locationChanges.Title;
                }
                if (locationChanges.City != locationRecord.LocationCity){
                    locationRecord.LocationCity = locationChanges.City;
                }
                if (locationChanges.State != locationRecord.LocationState){
                    locationRecord.LocationState = locationChanges.State;
                }
                if (locationChanges.Country != locationRecord.LocationCountry){
                    locationRecord.LocationCountry = locationChanges.Country;
                }
                if (locationChanges.Zip != locationRecord.LocationZip){
                    locationRecord.LocationZip = locationChanges.Zip;
                }
                await context.SaveChangesAsync();
            }
            return locationChanges;
        }
    }
}
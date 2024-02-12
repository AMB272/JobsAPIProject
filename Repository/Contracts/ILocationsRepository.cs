using JobsAPIProject.Models;
using JobsAPIProject.Entities.LocationEntities;

namespace JobsAPIProject.Repository.Contracts
{
    public interface ILocationsRepository
    {
        //Interfaces added as part of 'Repository' Design Pattern
        Task<IEnumerable<Location>> GetAllLocations();
        Task<LocationEntity> InsertLocation(LocationEntity location);
        Task<LocationEntity> UpdateLocation(int id, LocationEntity locationChanges); 
    }
}
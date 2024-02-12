using Microsoft.AspNetCore.Mvc;
using JobsAPIProject.Repository.Contracts;
using JobsAPIProject.Entities.LocationEntities;

namespace JobsAPIProject.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsRepository _locationsRepository;

        public LocationsController(ILocationsRepository locationsRepository)
        {
            _locationsRepository = locationsRepository;
        }

        /// <Summary>
        /// Inserts a new location entry based on parameters entered
        /// </Summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> InsertLocation(LocationEntity location)
        {
            var response = await _locationsRepository.InsertLocation(location); 
            return new ObjectResult(response);
        }

        /// <Summary>
        /// Updates exisitng location entries
        /// </Summary>
        [HttpPut("{id:min(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> UpdateLocation(int id, LocationEntity request)
        {
            var response = await _locationsRepository.UpdateLocation(id, request); 
            return new ObjectResult(response);
        }

        /// <Summary>
        /// Returns a list of all location entries present in the database
        /// </Summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> GetAllLocations()
        {
            var response = await _locationsRepository.GetAllLocations();
            return new ObjectResult(response);
        }
    }
}
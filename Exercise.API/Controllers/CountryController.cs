using Exercise.Exceptions;
using Exercise.Services.Models;
using Exercise.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;

namespace Exercise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllCountries()
        {
            try
            {
                return Ok(_countryService.GetAllCountries());
            }
            catch(CountryException ex)
            {
                Log.Error("Error while fetching countries list", ex.Message);
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                Log.Write(LogEventLevel.Fatal, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public IActionResult CreateCountry([FromBody] CountryServiceModel model)
        {
            try
            {
                _countryService.Create(model);
                return Ok();
            }
            catch (CountryException ex)
            {
                Log.Error("Error while creating new country.", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Fatal, ex.Message);
                return BadRequest("There was something wrong with the Api.");
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteCountry([FromRoute] int id)
        {
            try
            {
                _countryService.Delete(id);
                return Ok();
            }
            catch (CountryException ex)
            {
                Log.Error("Error while deleting country.", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Fatal, ex.Message);
                return BadRequest("There was something wrong with the Api.");
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateCountry([FromBody] CountryServiceModel model)
        {
            try
            {
                var updatedCountry = _countryService.Update(model);
                return Ok(updatedCountry);
            }
            catch (CountryException ex)
            {
                Log.Error("Error while updating country.", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Fatal, ex.Message);
                return BadRequest("There was something wrong with the Api.");
            }
        }
    }
}

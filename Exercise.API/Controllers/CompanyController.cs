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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllCompanies()
        {
            try
            {
                return Ok(_companyService.GetAllCompanies());

            }
            catch(CountryException ex)
            {
                Log.Error("Error while fetching countries", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Fatal, ex.Message);
                return BadRequest("There was something wrong with the Api.");
            }
        }

        [HttpPost("Create")]
        public ActionResult CreateCompany([FromBody] CompanyServiceModel model)
        {
            try
            {
                _companyService.Create(model);
                return Ok();
            }
            catch (CountryException ex)
            {
                Log.Error("Error while creating company", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Fatal, ex.Message);
                return BadRequest("There was something wrong with the Api.");
            }

        }

        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteCompany([FromRoute] int id)
        {
            try
            {
                _companyService.Delete(id);
                return Ok();
            }
            catch (CountryException ex)
            {
                Log.Error($"Error while deleting company", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Fatal, ex.Message);
                return BadRequest("There was something wrong with the Api.");
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateCompany([FromBody] CompanyServiceModel model)
        {
            try
            {
                var updatedCompany = _companyService.Update(model);
                return Ok(updatedCompany);
            }
            catch (CountryException ex)
            {
                Log.Error($"Error updating company, something went wrong", ex.Message);
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

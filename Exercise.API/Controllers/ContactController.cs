using Exercise.Exceptions;
using Exercise.ServiceModels;
using Exercise.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;

namespace Exercise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ICompanyService _companyService;
        private readonly ICountryService _countryService;

        public ContactController(IContactService contactService, ICompanyService companyService, ICountryService countryService)
        {
            _contactService = contactService;
            _companyService = companyService;
            _countryService = countryService;
        }

        [HttpGet("GetById/{id}")]
        public ActionResult GetContactById([FromRoute] int id)
        {
            try
            {
                Log.Information("Successfully fetched contact.");
                return Ok(_contactService.GetContactById(id));
            }
            catch (ContactException ex)
            {
                Log.Error("Error while fetching contact from database.", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Fatal, ex.Message);
                return BadRequest("There was something wrong with the Api.");
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllContacts()
        {
            try
            {
                var contacts = _contactService.GetContactsWithCompanyAndCountry();

                List<ContactDetails> contactDetails = new List<ContactDetails>();

                foreach (var contact in contacts)
                {
                    contactDetails.Add(new ContactDetails
                    {
                        Id = contact.Id,
                        Name = contact.Name,
                        Company = _companyService.GetCompanyById(contact.CompanyId).Name,
                        Country = _countryService.GetCountryById(contact.CountryId).Name
                    });
                }
                return Ok(contactDetails);
            }
            catch(ContactException ex)
            {
                Log.Error("Something went wrong while fetching contacts.");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Fatal, ex.Message);
                return BadRequest("There was something wrong with the Api.");
            }
        }

        [HttpGet("Filter")]
        public IActionResult FilterContacts([FromQuery] int countryId, [FromQuery] int companyId)
        {
            try
            {
                return Ok(_contactService.FilterContacts(companyId, countryId));
            }
            catch(ContactException ex)
            {
                Log.Error("There was an error while fetcing contacts", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Fatal, ex.Message);
                return BadRequest("There was something wrong with the Api.");
            }
        }

        [HttpPost("Create")]
        public IActionResult CreateContact([FromBody] ContactServiceModel model)
        {
            try
            {
                _contactService.Create(model);
                return Ok();
            }
            catch(ContactException ex)
            {
                Log.Error("Error creating new contact", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Fatal, ex.Message);
                return BadRequest("There was something wrong with the Api.");
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteContact([FromRoute] int id)
        {
            try
            {
                _contactService.Delete(id);
                return Ok();
            }
            catch(ContactException ex)
            {
                Log.Error("Error deleting contact", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Fatal, ex.Message);
                return BadRequest("There was something wrong with the Api.");
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateContact([FromBody] ContactServiceModel model)
        {
            try
            {
                var updatedContact = _contactService.Update(model);
                return Ok(updatedContact);
            }
            catch(ContactException ex)
            {
                Log.Error("Error updating contact.", ex.Message);
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

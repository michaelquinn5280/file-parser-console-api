using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using FileParser.Domain;
using FileParser.Domain.Entities;
using FileParser.WebApi.Models;

namespace FileParser.WebApi.Controllers
{
    /// <summary>
    /// Records Controller
    /// </summary>
    public class RecordsController : ApiController
    {
        /// <summary>
        /// Person Service
        /// </summary>
        private readonly IPersonService _personService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecordsController()
            : this(null)
        {
            
        }

        /// <summary>
        /// DI Contructor
        /// </summary>
        /// <param name="personService"></param>
        public RecordsController(IPersonService personService)
        {
            _personService = personService ?? new PersonService(WebApiApplication.People);
        }

        /// <summary>
        /// Get Records Ordered By Gender And Last Name
        /// </summary>
        /// <returns>People</returns>
        [HttpGet]
        [ResponseType(typeof(List<PersonViewModel>))]
        [Route("api/records/gender")]
        public IHttpActionResult GetRecordsOrderedByGenderAndLastName()
        {
            var response = _personService.GetPeopleOrderedByGenderAndLastName();
            return Ok(response.Select(p=> new PersonViewModel(p)));
        }

        /// <summary>
        /// Get Records Ordered By Birth Date
        /// </summary>
        /// <returns>Records</returns>
        [HttpGet]
        [ResponseType(typeof(List<Person>))]
        [Route("api/records/birthdate")]
        public IHttpActionResult GetRecordsOrderedByBirthDate()
        {
            var response = _personService.GetPeopleOrderedByBirthDate();
            return Ok(response);
        }

        /// <summary>
        /// Get Records Ordered By Last Name
        /// </summary>
        /// <returns>Records</returns>
        [HttpGet]
        [ResponseType(typeof(List<Person>))]
        [Route("api/records/name")]
        public IHttpActionResult GetRecordsOrderedByLastName()
        {
            var response = _personService.GetPeopleOrderedByLastName();
            return Ok(response);
        }

        /// <summary>
        /// Add Person Record
        /// </summary>
        /// <param name="personText">Person Text</param>
        /// <returns>Success Indicator</returns>
        [HttpPost]
        [Route("api/records/")]
        public IHttpActionResult AddPersonRecord(string personText)
        {
            if (string.IsNullOrWhiteSpace(personText))
                return BadRequest();

            var person = Domain.Helpers.Parser.ParsePerson(personText, null);
            if (person == null)
                return BadRequest();

            _personService.AddPerson(person);
            return Ok();
        }
    }
}

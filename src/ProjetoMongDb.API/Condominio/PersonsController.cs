using System.Collections.Generic;
using System.Threading.Tasks;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using Super.BffBackoffice.Application.UseCases.Person.LegalEntityDetails;
using Super.BffBackoffice.Application.UseCases.Person.PersonDetails;
using Super.BffBackoffice.Application.UseCases.Person.Persons;

namespace Super.BffBackoffice.API.Controllers.Person
{
    [ApiVersion("2")]    
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsUseCase _personsUseCase;
        private readonly IPersonDetailsUseCase _personDetailsUseCase;

        public PersonsController(IPersonsUseCase personsUseCase, IPersonDetailsUseCase personDetailsUseCase)
        {
            _personsUseCase = personsUseCase;
            _personDetailsUseCase = personDetailsUseCase;
        }

        /// <summary>
        /// Person by name, documet, email or mobile
        /// </summary>
        /// <response code="200">Successful consultation</response>
        /// <response code="422">A validation error occurred while querying</response>
        [HttpPost]
        [ProducesResponseType(typeof(PersonsResult), 200)]
        [ProducesResponseType(typeof(IEnumerable<Notification>), 422)]
        public async Task<IActionResult> GetPerson([FromQuery] PersonsRequest request)
        {
            var presenter = new PersonsPresenter();
            var resultado = await _personsUseCase.ExecuteAsync(request);
            presenter.OnPopulate(resultado);
            return presenter.ViewModel;
        }




    }
}
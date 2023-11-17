using Core.Entities;
using Core.UseCases.Users.Commands.CreateUser;
using Core.UseCases.Users.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllUsers")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<IEnumerable<User>>> GetAllUnitMeasures()
        {
            var query = new GetAllUsersQuery();
            var unitMeasures = await _mediator.Send(query);

            return Ok(unitMeasures);
        }

        [HttpPost(Name = "CreateUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateUnitMeasure([FromBody] CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return userId;
        }
    }
}

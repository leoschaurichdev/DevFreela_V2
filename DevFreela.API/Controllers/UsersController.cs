using DevFreela.Application.Commands.UserCommands.DeleteUser;
using DevFreela.Application.Commands.UserCommands.InsertUser;
using DevFreela.Application.Commands.UserCommands.LoginUser;
using DevFreela.Application.Commands.UserCommands.UpdateUser;
using DevFreela.Application.Queries.UsersQueries.GetAllUsers;
using DevFreela.Application.Queries.UsersQueries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GET api/users
        [HttpGet]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetAll(string search = "")
        {
            var query = new GetAllUserQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        //GETById api/users/id
        [HttpGet("{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        //POST api/users
        [HttpPost]
        [AllowAnonymous]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post(InsertUserCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        //PUT api/users/id
        [HttpPut("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Put(int id, UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        //DELETE api/users/id
        [HttpDelete("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if (loginUserViewModel == null)
            {
                return BadRequest();
            }

            return Ok(loginUserViewModel);

        }
    }
}
using KampETicaret.Application.Features.Commands.AppUserCommands.CreateAppUser;
using KampETicaret.Application.Features.Commands.AppUserCommands.DeleteAppUser;
using KampETicaret.Application.Features.Commands.AppUserCommands.UpdateAppUser;
using KampETicaret.Application.Features.Queries.AppUserQueries.GetAllAppUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KampETicaret.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost("CreateAsnyc")]
        public async Task<ActionResult> CreateUserAsnyc([FromBody]CreateAppUserCommand command)
        {
          var result= await Mediator.Send(command);
            return Created("",result);
        }

        [HttpPost("DeleteAsnyc")]
        public async Task<ActionResult> DeleteUserAsnyc([FromBody] DeleteAppUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPost("UpdateAsnyc")]
        public async Task<ActionResult> UpdateUserAsnyc([FromBody] UpdateAppUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Created("", result);
        }
        [HttpGet("getallAsnyc")]
        public async Task<ActionResult> GetAllUserAsnyc([FromQuery] GetAllAppUserQuery query)
        {
            var result = await Mediator.Send(query);
            return Created("", result);
        }
    }
}

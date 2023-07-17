using KampETicaret.Application.Features.Commands.AppUserCommands.CreateAppUser;
using KampETicaret.Application.Features.Commands.AppUserCommands.DeleteAppUser;
using KampETicaret.Application.Features.Commands.AppUserCommands.UpdateAppUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KampETicaret.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost("Create")]
        public async Task<ActionResult> CreateUser(CreateAppUserCommand command)
        {
          var result= await Mediator.Send(command);
            return Created("",result);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult> DeleteUser(DeleteAppUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPost("Update")]
        public async Task<ActionResult> UpdateUser(UpdateAppUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Created("", result);
        }
    }
}

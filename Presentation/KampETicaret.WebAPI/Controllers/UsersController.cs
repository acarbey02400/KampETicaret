using KampETicaret.Application.Features.Commands.AppUserCommands.CreateAppUser;
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
    }
}

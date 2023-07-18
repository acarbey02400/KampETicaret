using KampETicaret.Application.Features.Commands.AppUserCommands.CreateAppUser;
using KampETicaret.Application.Features.Queries.AuthQueries.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KampETicaret.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpGet("Login")]
        public async Task<ActionResult> CreateUserAsnyc([FromQuery] LoginAppUserQuery query)
        {
            var result = await Mediator.Send(query);
            return Created("", result);
        }
    }
}

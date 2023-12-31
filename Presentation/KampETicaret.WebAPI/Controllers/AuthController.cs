﻿using KampETicaret.Application.Features.Commands.AppUserCommands.CreateAppUser;
using KampETicaret.Application.Features.Queries.AuthQueries.Login;
using KampETicaret.Application.Features.Queries.AuthQueries.RefreshTokenLogin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KampETicaret.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpGet("Login")]
        public async Task<ActionResult> LoginAsnyc([FromQuery] LoginAppUserQuery query)
        {
            var result = await Mediator.Send(query);
            return Created("", result);
        }
        [HttpGet("RefreshTokenLogin")]
        public async Task<ActionResult> RefreshTokenLoginAsnyc([FromQuery] RefreshTokenLoginAppUserQuery query)
        {
            var result = await Mediator.Send(query);
            return Created("", result);
        }
    }
}

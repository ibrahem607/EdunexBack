﻿using AuthenticationMechanism.tokenservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduNexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly TokenService _tokenService;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthController(SignInManager<IdentityUser> signInManager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
        }
       

        [HttpPost("logout")]

        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();

            return Ok(new { message = "User logged out successfully." });

        }
    }
}

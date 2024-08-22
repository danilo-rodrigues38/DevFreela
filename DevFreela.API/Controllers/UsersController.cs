﻿using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        // api/users/1
        [HttpGet ( "{id}" )]
        public IActionResult GetById ( )
        {
            return Ok ( );
        }

        // api/users
        [HttpPost]
        public IActionResult Post( [FromBody] createUserModel createUserModel )
        {
            return CreatedAtAction ( nameof(GetById), new { id = 1 }, createUserModel );
        }

        // api/users/1/login
        [HttpPut("{id}/login")]
        public IActionResult Login ( int id, [FromBody] LoginModel loginModel )
        {
            return NoContent ( );
        }
    }
}
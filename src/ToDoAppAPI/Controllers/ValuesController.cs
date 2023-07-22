﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ToDoAppAPI.Utitlities.Auth;

namespace ToDoAppAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("Anonymous")]
        public string Anonymous() => "Anonymous";



        [Authorize]
        [HttpGet("Users")]
        public List<string> Users()
        {
            return GetClaims();
        }


        //[Authorize(Roles = "Admin, SuperAdmin")]
        [Authorize(Policy = Policies.AdministrativePolicy)]
        [HttpGet("Admin")]
        public List<string> Admins()
        {
            return GetClaims();
        }

        [Authorize(Roles = Roles.SuperAdmin)]
        [HttpGet("SuperAdmin")]
        public List<string> SuperAdmin()
        {
            return GetClaims();
        }




        private List<string> GetClaims()
        {
            return User.Claims.Select(claim => $"claimName={claim.Type}, claimValue={claim.Value})").ToList();
        }
    }
}
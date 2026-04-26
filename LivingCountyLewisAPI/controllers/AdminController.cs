using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using LivingCountyLewisAPI.Models;
using System;

namespace LivingCountyLewisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] Admin login)
        {
            // 🪵 Debug log: log username and password sent from Angular
            Console.WriteLine($"Login attempt: Username = {login.Username}, Password = {login.Password}");

            if (login.Username == "admin" && login.Password == "password123")
            {
                return Ok(new
                {
                    success = true,
                    token = "admin-access-token"
                });
            }
            else
            {
                return Unauthorized(new { success = false });
            }
        }
    }
}
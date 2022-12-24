using JwtAuth;
using JwtAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi4.Models;

namespace WebApi4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(JwtTokenHandler jwtTokenHandler, UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel authRequest)
        {
            var user = await _userManager.FindByNameAsync(authRequest.Username);
            if(user == null) return NotFound();
            var userRoles = await _userManager.GetRolesAsync(user);
            var authResponse = _jwtTokenHandler.GenerateJwtToken(authRequest, userRoles);
            return Ok(authResponse);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
    }
}

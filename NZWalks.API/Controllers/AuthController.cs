using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository _tokenRepository;
        //Register provides to register a user or to create a user so inject USER MANAGER CLASS
        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this._tokenRepository = tokenRepository;
        }
        //POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO requestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = requestDTO.Username,
                Email = requestDTO.Username
            };
            var identityResult = await userManager.CreateAsync(identityUser, requestDTO.Password);
            if(identityResult.Succeeded)
            {
                //Add roles to the user
                if (requestDTO.Roles!=null)
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, requestDTO.Roles);
                    if(identityResult.Succeeded)
                    {
                        return Ok("User registered successfully!");
                    }
                }
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var usercheck = await userManager.FindByEmailAsync(loginRequestDto.Username);
            if(usercheck != null)
            {
                var PasswordCheck = await userManager.CheckPasswordAsync(usercheck, loginRequestDto.Password);
                if (PasswordCheck)
                {
                    //Create Token
                    var roles = await userManager.GetRolesAsync(usercheck);
                    if (roles != null) 
                    {
                        var jwtToken = _tokenRepository.CreateJwtToken(usercheck, roles.ToList());
                        var response = new LoginResponseDTO()
                        {
                            JwtToken = jwtToken,
                        };
                        return Ok(response);
                    }
                    return Ok("Login successful");
                }

                    
                else
                {
                    return BadRequest("Invalid Username");
                }
            }           
            else
            {
                return BadRequest("Invalid Password");
            }
        }
    }
}

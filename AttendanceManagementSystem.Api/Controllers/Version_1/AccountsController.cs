
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using AttendanceManagementSystem.Authentication.Configurations;
using AttendanceManagementSystem.Authentication.DTOs.CreateDTOs;
using AttendanceManagementSystem.Authentication.DTOs.ReadDTOs;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AttendanceManagementSystem.Api.Controllers.Version_1;

public class AccountsController : BaseController
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtConfig _jwtConfig;
    public AccountsController(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        UserManager<IdentityUser> userManager,
        IOptionsMonitor<JwtConfig> optionsMonitor) : base(unitOfWork, mapper)
    {
        _userManager = userManager;
        _jwtConfig = optionsMonitor.CurrentValue;
    }

    [HttpPost]
    [Route("Register")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Registration([FromBody] UserRegistrationRequestCreateDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new UserRegistrationResponseReadDto
            {
                Success = false,
                Errors = [
                    "Invalid Payload"
                ]
            });
        }
        // Check For If The User Exists
        var userExist = await _userManager.FindByEmailAsync(userDto.Email);
        if (userExist is not null)
        {
            return BadRequest(new UserRegistrationResponseReadDto
            {
                Success = false,
                Errors = [
                    "Email Already In Use Login Instead."
                ]
            });
        }

        // Add New User
        var newUser = new IdentityUser
        {
            Email = userDto.Email,
            UserName = userDto.FirstName,
            EmailConfirmed = true // TODO Implement Confirmation Functionality
        };

        var isCreated = await _userManager.CreateAsync(newUser, userDto.Password);
        if (!isCreated.Succeeded)
        {
            return BadRequest(new UserRegistrationResponseReadDto
            {
                Success = isCreated.Succeeded,
                Errors = isCreated.Errors.Select(x => x.Description).ToList()
            });
        }

        // Create Jwt Token
        var token = GenerateJwtToken(newUser);

        return Ok(new UserRegistrationResponseReadDto
        {
            Success = true,
            Token = token
        });
    }

    private string GenerateJwtToken(IdentityUser user)
    {
        var jwtHanlder = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(3), // TODO Update this to minutes
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature // TODO Review The Alogrithm
            )
        };

        // * Generate the security token
        var token = jwtHanlder.CreateToken(tokenDescriptor);

        // * Convert this security token to sting and returns is back 
        return jwtHanlder.WriteToken(token);
    }
}
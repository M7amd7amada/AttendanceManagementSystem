using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using AttendanceManagementSystem.Authentication.Configurations;
using AttendanceManagementSystem.Authentication.DTOs.CreateDTOs;
using AttendanceManagementSystem.Authentication.DTOs.ReadDTOs;
using AttendanceManagementSystem.Domain.Models;
using AttendanceManagementSystem.Domain.Models.Enums;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AttendanceManagementSystem.Api.Controllers.Version_1.Authentication;

public class AccountsController : BaseController
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly JwtConfig _jwtConfig;
    private readonly IUsersRepository _users;
    private readonly IRefreshTokensRepository _refreshTokens;
    public AccountsController(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        UserManager<IdentityUser> userManager,
        IOptionsMonitor<JwtConfig> optionsMonitor,
        TokenValidationParameters tokenValidationParameters) : base(unitOfWork, mapper)
    {
        _userManager = userManager;
        _jwtConfig = optionsMonitor.CurrentValue;
        _users = _unitOfWork.Users;
        _refreshTokens = _unitOfWork.RefreshTokens;
        _tokenValidationParameters = tokenValidationParameters;
    }

    [HttpPost]
    [Route("Register")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Registration(
        [FromBody] UserRegistrationRequestCreateDto userDto)
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

        var userEntity = _mapper.Map<User>(userDto);
        userEntity.IdentityId = new Guid(newUser.Id);
        await _users.AddAsync(userEntity);
        await _unitOfWork.CompleteAsync();

        // Create Jwt Token
        var token = await GenerateJwtToken(newUser);

        return Ok(new UserRegistrationResponseReadDto
        {
            Success = true,
            Token = token
        });
    }

    [HttpPost]
    [Route("Login")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Login(
        [FromBody] UserLoginRequestCreateDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new UserLoginRequestReadDto
            {
                Success = false,
                Errors = [" Invalid Payload "]
            });
        }

        var userExist = await _userManager.FindByEmailAsync(userDto.Email);
        if (userExist is null)
        {
            return BadRequest(new UserLoginRequestReadDto
            {
                Success = false,
                Errors = [" Inavlid Authentication Request "]
            });
        }

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(userExist, userDto.Password);
        if (!isPasswordCorrect)
        {
            return BadRequest(new UserLoginRequestReadDto
            {
                Success = false,
                Errors = [" Wrong Password!! "]
            });
        }

        var jwtToken = await GenerateJwtToken(userExist);

        return Ok(new UserLoginRequestReadDto
        {
            Success = true,
            Token = jwtToken
        });
    }

    private async Task<string> GenerateJwtToken(IdentityUser user)
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
            Expires = DateTime.UtcNow.Add(_jwtConfig.ExpiryTimeFrame),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature // TODO Review The Alogrithm
            )
        };

        // * Generate the security token
        var token = jwtHanlder.CreateToken(tokenDescriptor);

        // * Convert this security token to sting and returns is back 
        var jwtToken = jwtHanlder.WriteToken(token);

        // * Generate refresh token
        var refreshToken = new RefreshToken
        {
            CreatedDate = DateTime.UtcNow,
            Token = $"{GenerateRandomString(32)}_{Guid.NewGuid()}",
            UserId = user.Id,
            IsRevoked = false,
            IsUsed = false,
            Status = Status.Active,
            JwtId = token.Id,
            ExpiryDate = DateTime.UtcNow.AddMonths(6)
        };

        await _refreshTokens.AddAsync(refreshToken);
        await _unitOfWork.CompleteAsync();

        return jwtToken;
    }

    private static string GenerateRandomString(int length)
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYz0123456789";

        return new string(
            Enumerable.Repeat(chars, length)
                .Select(str => str[random.Next(str.Length)])
                .ToArray()
        );
    }
}
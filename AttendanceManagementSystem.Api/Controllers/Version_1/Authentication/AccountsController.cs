using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using AttendanceManagementSystem.Authentication.Configurations;
using AttendanceManagementSystem.Authentication.DTOs.CreateDTOs;
using AttendanceManagementSystem.Authentication.DTOs.Generic;
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
        var tokenData = await GenerateJwtToken(newUser);

        return Ok(new UserRegistrationResponseReadDto
        {
            Success = true,
            Token = tokenData.JwtToken,
            RefreshToken = tokenData.RefreshToken
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

        var isPasswordCorrect = await _userManager
            .CheckPasswordAsync(userExist, userDto.Password);

        if (!isPasswordCorrect)
        {
            return BadRequest(new UserLoginRequestReadDto
            {
                Success = false,
                Errors = [" Wrong Password!! "]
            });
        }

        var tokenData = await GenerateJwtToken(userExist);

        return Ok(new UserLoginRequestReadDto
        {
            Success = true,
            Token = tokenData.JwtToken,
            RefreshToken = tokenData.RefreshToken
        });
    }

    [HttpPost]
    [Route("RefreshToken")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> RefreshToken(
        [FromBody] TokenRequestCreateDto tokenRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new UserLoginRequestReadDto
            {
                Success = false,
                Errors = [" Invalid Payload "]
            });
        }

        var result = await VerifyToken(tokenRequest);

        if (result is null)
        {
            return BadRequest(new UserLoginRequestReadDto
            {
                Success = false,
                Errors = [" Token Validation Failed "]
            });
        }

        return Ok(result);
    }

    private async Task<AuthResultReadDto> VerifyToken(TokenRequestCreateDto tokenDto)
    {
        var tokenHanlder = new JwtSecurityTokenHandler();

        try
        {
            var principal = tokenHanlder.ValidateToken(
                tokenDto.Token,
                _tokenValidationParameters,
                out var validatedToken);

            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                var result = jwtSecurityToken
                    .Header
                    .Alg
                    .Equals(SecurityAlgorithms.HmacSha256,
                        StringComparison.InvariantCultureIgnoreCase);

                if (!result) return null!;
            }

            var utcExpiryDate = long.Parse(principal.Claims.FirstOrDefault(x =>
                x.Type == JwtRegisteredClaimNames.Exp)!.Value);

            var expDate = UnixTimeStampToDateTime(utcExpiryDate);

            if (expDate > DateTime.UtcNow)
            {
                return new AuthResultReadDto
                {
                    Success = false,
                    Errors = [" Refresh Token Had Expired "]
                };
            }

            var refreshTokenExist = await _refreshTokens.GetByRefreshTokenAsync(tokenDto.RefreshToken);
            if (refreshTokenExist is null)
            {
                return new AuthResultReadDto
                {
                    Success = false,
                    Errors = [" Refresh Token Doesn't Exist "]
                };
            }

            if (refreshTokenExist.ExpiryDate < DateTime.UtcNow)
            {
                return new AuthResultReadDto
                {
                    Success = false,
                    Errors = [" Refresh Token Had Expired Pleas Login Again. "]
                };
            }

            if (refreshTokenExist.IsUsed)
            {
                return new AuthResultReadDto
                {
                    Success = false,
                    Errors = [" Refresh Token Had been used, it cann't be reused. "]
                };
            }

            if (refreshTokenExist.IsRevoked)
            {
                return new AuthResultReadDto
                {
                    Success = false,
                    Errors = [" Refresh Token Had been revoked, it cann't be used. "]
                };
            }

            var jti = principal.Claims.SingleOrDefault(x =>
                x.Type == JwtRegisteredClaimNames.Jti)!.Value;

            if (refreshTokenExist.JwtId != jti)
            {
                return new AuthResultReadDto
                {
                    Success = false,
                    Errors = [" Refresh Toekn reference does not match the jwt token. "]
                };
            }

            refreshTokenExist.IsUsed = true;
            var updatedResult = await _refreshTokens.MarkRefreshTokenAsUsedAsync(refreshTokenExist);

            if (updatedResult)
            {
                await _unitOfWork.CompleteAsync();

                var dbUser = await _userManager.FindByIdAsync(refreshTokenExist.UserId!);

                if (dbUser is null)
                {
                    return new AuthResultReadDto
                    {
                        Success = false,
                        Errors = [" Error Processing Request "]
                    };
                }

                var tokens = await GenerateJwtToken(dbUser);

                return new AuthResultReadDto
                {
                    Success = true,
                    Token = tokens.JwtToken,
                    RefreshToken = tokens.RefreshToken
                };
            }
            else
            {
                return new AuthResultReadDto
                {
                    Success = false,
                    Errors = [" Error Processing Request "]
                };
            }
        }
        catch
        {
            // TODO Implement Error Handling
            return null!;
        }
    }

    private DateTime UnixTimeStampToDateTime(long utcExpiryDate)
    {
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        dateTime = dateTime.AddSeconds(utcExpiryDate).ToUniversalTime();
        return dateTime;
    }

    private async Task<TokenDataDto> GenerateJwtToken(IdentityUser user)
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

        var tokenData = new TokenDataDto
        {
            JwtToken = jwtToken,
            RefreshToken = refreshToken.Token
        };

        return tokenData;
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
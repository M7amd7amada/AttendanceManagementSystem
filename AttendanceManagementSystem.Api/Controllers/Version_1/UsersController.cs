using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace AttendanceManagementSystem.Api.Controllers.Version_1;
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UsersController : BaseController
{
    private readonly IUsersRepository _users;

    public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _users = unitOfWork.Users;
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAllUsersAsync()
    {

        var users = await _users.GetAllAsync();
        var response = _mapper.Map<IEnumerable<UserReadDto>>(users);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(response);
    }
}
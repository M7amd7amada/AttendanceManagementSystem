
namespace AttendanceManagementSystem.Api.Controllers.Version_1.LeaveRequests;

public partial class LeaveRequestsController : BaseController
{
    private readonly ILeaveRequestsRepostiory _leaveRequests;
    public LeaveRequestsController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _leaveRequests = unitOfWork.LeaveRequests;
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<LeaveRequestReadDto>>> GetAllAsync()
    {

        var leaveRequests = await _leaveRequests.GetAllAsync();

        if (leaveRequests is null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _mapper.Map<IEnumerable<LeaveRequestReadDto>>(leaveRequests);

        return Ok(response);
    }


    [HttpGet]
    [Route("GetLeaveRequest")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<LeaveRequestReadDto>> GetByIdAsync(Guid id)
    {
        var leaveRequest = await _leaveRequests.GetByIdAsync(id);

        if (leaveRequest is null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _mapper.Map<LeaveRequestReadDto>(leaveRequest);

        return Ok(response);
    }
}
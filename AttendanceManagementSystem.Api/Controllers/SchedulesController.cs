namespace AttendanceManagementSystem.Api.Controllers;

public class SchedulesController : BaseController
{
    private readonly ISchedulesRepository _schedules;
    public SchedulesController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _schedules = unitOfWork.Schedules;
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<ScheduleReadDto>>> GetAllAsync()
    {
        var schedules = await _schedules.GetAllAsync();
        var response = _mapper.Map<IEnumerable<ScheduleReadDto>>(schedules);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(response);
    }
}
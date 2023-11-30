namespace AttendanceManagementSystem.Api.Controllers.Version_1.Schedules;

public partial class SchedulesController : BaseController
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
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<ScheduleReadDto>>> GetAllAsync()
    {
        var schedules = await _schedules.GetAllAsync();

        if (schedules is null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _mapper.Map<IEnumerable<ScheduleReadDto>>(schedules);

        return Ok(response);
    }

    [HttpGet]
    [Route("WorkingHoursCount")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetWorkingHoursCount(Guid id)
    {
        try
        {
            var response = await _schedules.GetWorkingHoursCountAsync(id);
            return Ok(response);
        }
        catch (ArgumentNullException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("WorkingDaysCount")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<ScheduleReadDto>>> GetWorkingDaysCount(Guid id)
    {
        try
        {
            var response = await _schedules.GetWorkingDaysCountAsync(id);
            return Ok(response);
        }
        catch (ArgumentNullException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("GetAllWithUsers")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<ScheduleReadDto>>> GetAllWithUsers()
    {
        var schedules = await _schedules.FindAllAsync(sch => true, ["Users"]);

        if (schedules is null) return NotFound();

        var response = _mapper.Map<IEnumerable<ScheduleReadDto>>(schedules);

        return Ok(response);
    }

    [HttpGet]
    [Route("GetById")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<ScheduleReadDto>> GetByIdAsync(Guid id)
    {
        var schedule = await _schedules.GetByIdAsync(id);

        if (schedule is null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _mapper.Map<ScheduleReadDto>(schedule);

        return Ok(response);
    }


    [HttpGet]
    [Route("CountSchedules")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<int>> Count()
    {
        return Ok(await _schedules.CountAsync());
    }
}
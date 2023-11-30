
namespace AttendanceManagementSystem.Api.Controllers.Version_1.Attendances;

public partial class AttendancesController : BaseController
{
    private readonly IAttendancesRepository _attendances;
    public AttendancesController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _attendances = unitOfWork.Attendances;
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<AttendanceReadDto>>> GetAllAsync()
    {

        var attendances = await _attendances.GetAllAsync();

        if (attendances is null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _mapper.Map<IEnumerable<AttendanceReadDto>>(attendances);

        return Ok(response);
    }


    [HttpGet]
    [Route("GetAttendance")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<AttendanceReadDto>> GetByIdAsync(Guid id)
    {
        var attendance = await _attendances.GetByIdAsync(id);

        if (attendance is null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _mapper.Map<AttendanceReadDto>(attendance);

        return Ok(response);
    }
}
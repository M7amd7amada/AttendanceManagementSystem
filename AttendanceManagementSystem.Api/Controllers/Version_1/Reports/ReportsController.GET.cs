namespace AttendanceManagementSystem.Api.Controllers.Version_1.Reports;

public partial class ReportsController : BaseController
{
    private readonly IReportsRepository _reports;
    public ReportsController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _reports = unitOfWork.Reports;
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<ReportReadDto>>> GetAllAsync()
    {

        var reports = await _reports.GetAllAsync();

        if (reports is null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _mapper.Map<IEnumerable<ReportReadDto>>(reports);

        return Ok(response);
    }

    [HttpGet]
    [Route("GetReport")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<ReportReadDto>> GetByIdAsync(Guid id)
    {
        var report = await _reports.GetByIdAsync(id);

        if (report is null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _mapper.Map<ReportReadDto>(report);

        return Ok(response);
    }
}
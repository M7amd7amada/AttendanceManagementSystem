
namespace AttendanceManagementSystem.Api.Controllers.Version_1.Payrolls;

public partial class PayrollsController : BaseController
{
    private readonly IPayrollsRepository _payrolls;
    public PayrollsController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _payrolls = unitOfWork.Payrolls;
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<PayrollReadDto>>> GetAllAsync()
    {

        var payrolls = await _payrolls.GetAllAsync();

        if (payrolls is null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _mapper.Map<IEnumerable<PayrollReadDto>>(payrolls);

        return Ok(response);
    }


    [HttpGet]
    [Route("GetPayroll")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<PayrollReadDto>> GetByIdAsync(Guid id)
    {
        var payroll = await _payrolls.GetByIdAsync(id);

        if (payroll is null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _mapper.Map<PayrollReadDto>(payroll);

        return Ok(response);
    }
}
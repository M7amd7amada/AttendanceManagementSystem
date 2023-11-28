
namespace AttendanceManagementSystem.Api.Controllers.Version_1;

public class PayrollsController : BaseController
{
    private readonly IPayrollsRepository _payrolls;
    public PayrollsController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _payrolls = unitOfWork.Payrolls;
    }
}
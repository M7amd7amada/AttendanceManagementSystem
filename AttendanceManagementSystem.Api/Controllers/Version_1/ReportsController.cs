namespace AttendanceManagementSystem.Api.Controllers.Version_1;

public class ReportsController : BaseController
{
    private readonly IReportsRepository _reports;
    public ReportsController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _reports = unitOfWork.Reports;
    }
}
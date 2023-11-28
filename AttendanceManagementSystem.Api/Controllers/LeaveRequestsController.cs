
namespace AttendanceManagementSystem.Api.Controllers;

public class LeaveRequestsController : BaseController
{
    private readonly ILeaveRequestsRepostiory _leaveRequests;
    public LeaveRequestsController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _leaveRequests = unitOfWork.LeaveRequests;
    }
}
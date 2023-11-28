
namespace AttendanceManagementSystem.Api.Controllers;

public class AttendancesController : BaseController
{
    private readonly IAttendancesRepository _attendances;
    public AttendancesController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _attendances = unitOfWork.Attendances;
    }
}
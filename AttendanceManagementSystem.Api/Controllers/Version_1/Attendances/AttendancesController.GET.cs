
namespace AttendanceManagementSystem.Api.Controllers.Version_1.Attendances;

public partial class AttendancesController : BaseController
{
    private readonly IAttendancesRepository _attendances;
    public AttendancesController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _attendances = unitOfWork.Attendances;
    }
}
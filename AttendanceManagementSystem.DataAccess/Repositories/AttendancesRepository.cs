
namespace AttendanceManagementSystem.DataAccess.Repositories;

public class AttendancesRepository(AppDbContext context)
    : RepositoryBase<Attendance>(context),
        IAttendancesRepository
{
    public int WorkingHours { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Task<IEnumerable<Guid>> GetAllUsers()
    {
        throw new NotImplementedException();
    }
}
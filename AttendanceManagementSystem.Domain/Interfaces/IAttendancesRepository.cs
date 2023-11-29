namespace AttendanceManagementSystem.Domain.Interfaces;

public interface IAttendancesRepository : IRepositoryBase<Attendance>
{
    public int WorkingHours { get; set; }
    public Task<IEnumerable<Guid>> GetAllUsers();
}
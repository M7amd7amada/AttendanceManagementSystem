using AttendanceManagementSystem.Domain.DTOs.CreateDTOs;

namespace AttendanceManagementSystem.Domain.Interfaces;

public interface IAttendancesRepository : IRepositoryBase<Attendance>
{
    public int WorkingHours { get; }
    public Task<IEnumerable<Guid>> GetAllUsers();
    public Task CreateAttendance(Attendance attendance, Guid userId);
}
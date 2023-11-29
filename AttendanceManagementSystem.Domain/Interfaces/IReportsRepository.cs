namespace AttendanceManagementSystem.Domain.Interfaces;

public interface IReportsRepository : IRepositoryBase<Report>
{
    public Task GenerateAttendancesReport();
    public Task GeneratePayrollsReport();
    public Task GenerateLeaveRequestsReport();
    public Task GenerateUserReport(Guid id);
}
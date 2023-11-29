namespace AttendanceManagementSystem.Domain.Interfaces;

public interface IPayrollsRepository : IRepositoryBase<Payroll>
{
    public decimal TotalExpenses { get; set; }
    public Task<IEnumerable<Guid>> GetUsers();
}
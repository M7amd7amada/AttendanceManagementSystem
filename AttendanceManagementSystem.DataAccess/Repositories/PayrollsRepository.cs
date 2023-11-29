
namespace AttendanceManagementSystem.DataAccess.Repositories;

public class PayrollsRepository(AppDbContext context)
    : RepositoryBase<Payroll>(context),
        IPayrollsRepository
{
    public decimal TotalExpenses { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Task<IEnumerable<Guid>> GetUsers()
    {
        throw new NotImplementedException();
    }
}
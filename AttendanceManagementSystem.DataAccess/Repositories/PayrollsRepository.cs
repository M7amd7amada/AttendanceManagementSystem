namespace AttendanceManagementSystem.DataAccess.Repositories;

public class PayrollsRepository(AppDbContext context)
    : RepositoryBase<Payroll>(context),
        IPayrollsRepository
{
}
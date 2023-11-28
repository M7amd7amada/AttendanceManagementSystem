namespace AttendanceManagementSystem.DataAccess.Repositories;

public class UsersRepository(AppDbContext context)
    : RepositoryBase<User>(context),
        IUsersRepository
{
}
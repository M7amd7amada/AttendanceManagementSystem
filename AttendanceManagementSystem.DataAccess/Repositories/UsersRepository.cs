using AttendanceManagementSystem.DataAccess.Data;
using AttendanceManagementSystem.Domain.Interfaces;
using AttendanceManagementSystem.Domain.Models;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class UsersRepository(AppDbContext context)
    : RepositoryBase<User>(context), IUsersRepository
{
}
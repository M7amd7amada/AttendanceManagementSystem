using AttendanceManagementSystem.DataAccess.Data;
using AttendanceManagementSystem.DataAccess.Repositories;
using AttendanceManagementSystem.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace AttendanceManagementSystem.Api.Extensions;

public static class Extensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        string connectionString = builder.Configuration
            .GetConnectionString("SqlServerConnectionString")!;

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                connectionString,
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
    }
}
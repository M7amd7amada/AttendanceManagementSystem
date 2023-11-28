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

        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        builder.Services.AddTransient<SeedData>();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                connectionString,
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
    }

    public static void SeedData(this IHost app)
    {
        var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

        using var scope = (scopedFactory
            ?? throw new ArgumentNullException(nameof(scopedFactory))).CreateScope();
        var service = scope.ServiceProvider.GetService<SeedData>();
        (service ?? throw new ArgumentNullException(nameof(service))).Seed();
    }
}
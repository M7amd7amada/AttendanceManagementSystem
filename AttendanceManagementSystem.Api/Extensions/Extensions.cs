using System.Text;

using AttendanceManagementSystem.DataAccess.Data;
using AttendanceManagementSystem.DataAccess.Repositories;
using AttendanceManagementSystem.Authentication.Configurations;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace AttendanceManagementSystem.Api.Extensions;

public static class Extensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        string connectionString = builder.Configuration
            .GetConnectionString("SqlServerConnectionString")!;
        var jwtConfig = builder.Configuration.GetSection("JwtConfig");
        var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]!);
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateLifetime = true,
            ValidateIssuer = false,         // ToDo Update
            ValidateAudience = false,       // ToDo Update
            RequireExpirationTime = false   // ToDo Update
        };

        builder.Services.Configure<JwtConfig>(jwtConfig);
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(jwt =>
        {
            jwt.SaveToken = true;
            jwt.TokenValidationParameters = tokenValidationParameters;
        });
        builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            options.SignIn.RequireConfirmedEmail = true)
        .AddEntityFrameworkStores<AppDbContext>();

        builder.Services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "AttendanceMS.Api", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });



        builder.Services.AddControllers();
        builder.Services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.DefaultApiVersion = ApiVersion.Default;
            options.AssumeDefaultVersionWhenUnspecified = true;
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        builder.Services.AddTransient<SeedData>();
        builder.Services.AddSingleton(tokenValidationParameters);

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                connectionString,
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        builder.Services.AddCors(options =>
            options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                }));
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
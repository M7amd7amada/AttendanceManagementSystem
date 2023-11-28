using AttendanceManagementSystem.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (args.Length == 1 && args[0].Equals("SeedData", StringComparison.CurrentCultureIgnoreCase))
{
    app.SeedData();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
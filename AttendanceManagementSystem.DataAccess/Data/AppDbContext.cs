using AttendanceManagementSystem.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace AttendanceManagementSystem.DataAccess.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<Payroll> Payrolls { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<PayrollReport> PayrollReports { get; set; }
    public DbSet<AttendanceReport> AttendanceReports { get; set; }
    public DbSet<LeaveRequestReport> LeaveRequestReports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PayrollReport>()
            .HasKey(x => new { x.ReportId, x.PayrollId });

        modelBuilder.Entity<AttendanceReport>()
            .HasKey(x => new { x.ReportId, x.AttendanceId });

        modelBuilder.Entity<LeaveRequestReport>()
            .HasKey(x => new { x.ReportId, x.LeaveRequestId });
    }
}
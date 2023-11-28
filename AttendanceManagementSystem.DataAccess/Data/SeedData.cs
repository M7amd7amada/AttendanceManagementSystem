using AttendanceManagementSystem.Domain.Models;
using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.DataAccess.Data;

public class SeedData(AppDbContext context)
{
    private readonly AppDbContext _context = context;
    public void Seed()
    {
        if (!_context.Users.Any())
        {
            Console.WriteLine("---> Seeding Data...");
            var users = new List<User>
            {
                new User
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    Phone = "987-654-3210",
                    Schedule = new Schedule
                    {
                        StartTime = new TimeOnly(9, 0),
                        EndTime = new TimeOnly(18, 0),
                        WorkDays = new List<DaysOfWeek> { DaysOfWeek.Tuesday, DaysOfWeek.Thursday, DaysOfWeek.Saturday }
                    },
                    Attendances = new List<Attendance>
                    {
                        new Attendance
                        {
                            DayOfWeek = DaysOfWeek.Tuesday,
                            ClockInTime = new TimeOnly(9, 0),
                            ClockOutTime = new TimeOnly(18, 0),
                            AttendanceReports = new List<AttendanceReport>
                            {
                                new AttendanceReport
                                {
                                    Report = new Report
                                    {
                                        ReportDate = DateTime.UtcNow.Date,
                                        ReportType = ReportType.Daily,
                                        ReportDetails = "Daily attendance report for Jane Smith."
                                    }
                                }
                            }
                        }
                    },
                    LeaveRequests = new List<LeaveRequest>
                    {
                        new LeaveRequest
                        {
                            LeaveType = LeaveType.Sick,
                            LeaveStartDate = DateTime.UtcNow.Date.AddDays(3),
                            LeaveEndDate = DateTime.UtcNow.Date.AddDays(5),
                            LeaveStatus = LeaveStatus.Pending,
                            LeaveRequestReports = new List<LeaveRequestReport>
                            {
                                new LeaveRequestReport
                                {
                                    Report = new Report
                                    {
                                        ReportDate = DateTime.UtcNow.Date,
                                        ReportType = ReportType.Weekly,
                                        ReportDetails = "Leave request report for Jane Smith."
                                    }
                                }
                            }
                        }
                    },
                    Payrolls = new List<Payroll>
                    {
                        new Payroll
                        {
                        PayPeriodStart = new DateOnly(2023, 1, 1),
                        PayPerionEnd = new DateOnly(2023, 1, 15),
                        BaseSalary = 5500.00m,
                        TotalPay = 5000.00m,
                        PayrollReports = new List<PayrollReport>
                            {
                                new PayrollReport
                                {
                                    Report = new Report
                                    {
                                        ReportDate = DateTime.UtcNow.Date,
                                        ReportType = ReportType.Monthly,
                                        ReportDetails = "Payroll report for Jane Smith."
                                    }
                                }
                            }
                        }
                    }
                },
                new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Phone = "123-456-7890",
                    Schedule = new Schedule
                    {
                        StartTime = new TimeOnly(8, 0),
                        EndTime = new TimeOnly(17, 0),
                        WorkDays = new List<DaysOfWeek> { DaysOfWeek.Monday, DaysOfWeek.Wednesday, DaysOfWeek.Friday }
                    },
                    Attendances = new List<Attendance>
                    {
                        new Attendance
                        {
                            DayOfWeek = DaysOfWeek.Monday,
                            ClockInTime = new TimeOnly(8, 0),
                            ClockOutTime = new TimeOnly(17, 0),
                            AttendanceReports = new List<AttendanceReport>
                            {
                                new AttendanceReport
                                {
                                    Report = new Report
                                    {
                                        ReportDate = DateTime.UtcNow.Date,
                                        ReportType = ReportType.Daily,
                                        ReportDetails = "Daily attendance report for John Doe."
                                    }
                                }
                            }
                        }
                    },
                    LeaveRequests = new List<LeaveRequest>
                    {
                        new LeaveRequest
                        {
                            LeaveType = LeaveType.Vacation,
                            LeaveStartDate = DateTime.UtcNow.Date.AddDays(7),
                            LeaveEndDate = DateTime.UtcNow.Date.AddDays(14),
                            LeaveStatus = LeaveStatus.Pending,
                            LeaveRequestReports = new List<LeaveRequestReport>
                            {
                                new LeaveRequestReport
                                {
                                    Report = new Report
                                    {
                                        ReportDate = DateTime.UtcNow.Date,
                                        ReportType = ReportType.Weekly,
                                        ReportDetails = "Leave request report for John Doe."
                                    }
                                }
                            }
                        }
                    },
                    Payrolls = new List<Payroll>
                    {
                        new Payroll
                        {
                            PayPeriodStart = new DateOnly(2023, 1, 1),
                            PayPerionEnd = new DateOnly(2023, 1, 15),
                            BaseSalary = 5000.00m,
                            TotalPay = 4500.00m,
                            PayrollReports = new List<PayrollReport>
                            {
                                new PayrollReport
                                {
                                    Report = new Report
                                    {
                                        ReportDate = DateTime.UtcNow.Date,
                                        ReportType = ReportType.Monthly,
                                        ReportDetails = "Payroll report for John Doe."
                                    }
                                }
                            }
                        }
                    }
                }
            };

            _context.Users.AddRange(users);
            _context.SaveChanges();
        }
    }
}
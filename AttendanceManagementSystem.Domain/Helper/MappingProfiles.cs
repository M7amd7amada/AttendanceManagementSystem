using AttendanceManagementSystem.Domain.DTOs.CreateDTOs;
using AttendanceManagementSystem.Domain.DTOs.ReadDTOs;
using AttendanceManagementSystem.Domain.DTOs.UpdateDTOs;

using AutoMapper;

namespace AttendanceManagementSystem.Domain.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Users
        CreateMap<User, UserReadDto>();
        CreateMap<UserCreateDto, User>();

        // Schedules
        CreateMap<Schedule, ScheduleReadDto>();
        CreateMap<ScheduleCreateDto, Schedule>();
        CreateMap<ScheduleUpdateDto, Schedule>();

        // Reports
        CreateMap<Report, ReportReadDto>();
        CreateMap<ReportCreateDto, Report>();

        // Payrolls
        CreateMap<Payroll, PayrollReadDto>();
        CreateMap<PayrollCreateDto, Payroll>();

        // Leave Requests
        CreateMap<LeaveRequest, LeaveRequestReadDto>();
        CreateMap<LeaveRequestCreateDto, LeaveRequest>();

        // Attendances
        CreateMap<Attendance, AttendanceReadDto>();
        CreateMap<AttendanceCreateDto, Attendance>();
    }
}
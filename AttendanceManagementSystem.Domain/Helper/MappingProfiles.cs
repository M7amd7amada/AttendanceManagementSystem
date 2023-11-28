using AttendanceManagementSystem.Domain.DTOs.CreateDTOs;
using AttendanceManagementSystem.Domain.DTOs.ReadDTOs;
using AttendanceManagementSystem.Domain.Models;

using AutoMapper;

namespace AttendanceManagementSystem.Domain.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserReadDto>();
        CreateMap<UserCreateDto, User>();
    }
}
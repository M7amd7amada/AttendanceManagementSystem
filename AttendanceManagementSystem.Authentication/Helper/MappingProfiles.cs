using AttendanceManagementSystem.Authentication.DTOs.CreateDTOs;
using AttendanceManagementSystem.Domain.Models;

using AutoMapper;

namespace AttendanceManagementSystem.Authentication.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserRegistrationRequestCreateDto, User>()
            .ForSourceMember(x => x.Password, options => options.DoNotValidate())
            .ForMember(user => user.IdentityId, options => options.Ignore());
    }
}
using AttendanceManagementSystem.Domain.DTOs.ReadDTOs;
using AttendanceManagementSystem.Domain.Interfaces;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;


namespace AttendanceManagementSystem.Api.Controllers;

public class SchedulesController : BaseController
{
    private readonly ISchedulesRepository _repo;
    public SchedulesController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _repo = unitOfWork.Schedules;
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<ScheduleReadDto>>> GetAllAsync()
    {
        var schedules = await _repo.GetAllAsync();
        var response = _mapper.Map<IEnumerable<ScheduleReadDto>>(schedules);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(response);
    }
}
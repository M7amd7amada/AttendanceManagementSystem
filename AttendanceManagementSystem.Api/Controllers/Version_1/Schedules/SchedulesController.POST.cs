using AttendanceManagementSystem.Domain.Models;

namespace AttendanceManagementSystem.Api.Controllers.Version_1.Schedules;

public partial class SchedulesController
{
    [HttpPost]
    [Route("CreateSchedule")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> CreateSchedule(ScheduleCreateDto scheduleDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var schedule = _mapper.Map<Schedule>(scheduleDto);
        await _schedules.AddAsync(schedule);
        await _unitOfWork.CompleteAsync();

        return Ok();
    }

    [HttpPost]
    [Route("CreateSchedules")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> AddRange(
        IEnumerable<ScheduleCreateDto> scheduleDtos)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var schedules = _mapper.Map<IEnumerable<Schedule>>(scheduleDtos);
        await _schedules.AddRangeAsync(schedules);
        await _unitOfWork.CompleteAsync();

        return CreatedAtRoute(nameof(GetAll), schedules);
    }
}
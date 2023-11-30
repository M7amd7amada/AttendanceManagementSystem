using AttendanceManagementSystem.Domain.DTOs.UpdateDTOs;
using AttendanceManagementSystem.Domain.Models;

namespace AttendanceManagementSystem.Api.Controllers.Version_1.Schedules;

public partial class SchedulesController
{
    [HttpPut]
    [Route("UpdateSchedule")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(
        [FromBody] ScheduleUpdateDto scheduleDto
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var schedule = _mapper.Map<Schedule>(scheduleDto);

        _schedules.Update(schedule);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }
}
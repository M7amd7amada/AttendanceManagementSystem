namespace AttendanceManagementSystem.Api.Controllers.Version_1.Schedules;

public partial class SchedulesController
{
    [HttpDelete]
    [Route("DeleteSchedule")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> Delete(Guid scheduleId)
    {
        var schedule = await _schedules.GetByIdAsync(scheduleId);
        if (schedule is null)
        {
            return NotFound();
        }
        _schedules.Delete(schedule);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteSchedules")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteSchedules(IEnumerable<Guid> schedules)
    {
        foreach (var scheduleId in schedules)
        {
            var schedule = await _schedules.GetByIdAsync(scheduleId);
            if (schedule is null)
            {
                return NotFound();
            }
            _schedules.Delete(schedule);
        }
        await _unitOfWork.CompleteAsync();
        return Ok();
    }

}
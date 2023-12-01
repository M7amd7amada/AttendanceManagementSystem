using AttendanceManagementSystem.Domain.Models;

namespace AttendanceManagementSystem.Api.Controllers.Version_1.Attendances;

public partial class AttendancesController
{
    [HttpPost]
    [Route("CreateAttendance")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> CreateSchedule(ScheduleCreateDto attendanceDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var attendance = _mapper.Map<Attendance>(attendanceDto);
        await _attendances.AddAsync(attendance);
        await _unitOfWork.CompleteAsync();

        return Created();
    }

}
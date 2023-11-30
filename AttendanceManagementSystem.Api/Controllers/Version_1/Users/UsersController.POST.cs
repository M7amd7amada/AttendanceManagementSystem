namespace AttendanceManagementSystem.Api.Controllers.Version_1.Users;

public partial class UsersController
{
    [HttpPost]
    [Route("SubscribeToSchedule")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> SubscribeToSchedule(Guid userId, Guid scheduleId)
    {
        try
        {
            await _users.SubscribeToSchedule(userId, scheduleId);
            return Ok();
        }
        catch (ArgumentNullException)
        {
            return NotFound();
        }
    }
}
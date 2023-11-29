using System.Xml.Schema;

using AttendanceManagementSystem.Domain.Models;

namespace AttendanceManagementSystem.Api.Controllers.Version_1;

public class SchedulesController : BaseController
{
    private readonly ISchedulesRepository _schedules;
    public SchedulesController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _schedules = unitOfWork.Schedules;
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<ScheduleReadDto>>> GetAll()
    {
        var schedules = await _schedules.GetAllAsync();
        var response = _mapper.Map<IEnumerable<ScheduleReadDto>>(schedules);

        return Ok(response);
    }

    [HttpGet]
    [Route("GetById")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var schedule = await _schedules.GetByIdAsync(id);
        var response = _mapper.Map<ScheduleReadDto>(schedule);

        return Ok(response);
    }


    [HttpPost]
    [Route("CreateSchedule")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateSchedule(ScheduleCreateDto scheduleDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var schedule = _mapper.Map<Schedule>(scheduleDto);
        await _schedules.AddAsync(schedule);
        await _unitOfWork.CompleteAsync();

        return CreatedAtRoute(nameof(GetById), new { id = schedule.Id });
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

    [HttpGet]
    [Route("CountSchedules")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<int>> Count()
    {
        return Ok(await _schedules.CountAsync());
    }

    [HttpDelete]
    [Route("DeleteSchedule")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
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
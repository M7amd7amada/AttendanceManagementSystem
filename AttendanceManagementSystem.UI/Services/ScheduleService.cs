using AttendanceManagementSystem.Domain.DTOs.ReadDTOs;
using AttendanceManagementSystem.UI.Services.Contracts;

using System.Net;

namespace AttendanceManagementSystem.UI.Services;

public class ScheduleService(HttpClient httpClient) : IScheduleService
{
    private readonly HttpClient _httpClient = httpClient;

    public Task CreateSchedule()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ScheduleReadDto>> GetSchedulesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/v1/schedules/getall");

            if (response.IsSuccessStatusCode)
            {
                return response.StatusCode == HttpStatusCode.NoContent
                    ? Enumerable.Empty<ScheduleReadDto>()
                    : await response.Content.ReadFromJsonAsync<IEnumerable<ScheduleReadDto>>()
                    ?? throw new ArgumentNullException();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status code: {response.StatusCode} message: {message}");
            }

        }
        catch (Exception)
        {
            //Log exception
            throw;
        }
    }
}
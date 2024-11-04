namespace GymSphere.Services.ScheduleService;

public interface IScheduleService
{
    Task<Result<PagedResponse<IEnumerable<ScheduleReadInfo>>>> GetSchedules(ScheduleFilter filter);
    Task<Result<ScheduleReadInfo>> GetScheduleById(int id);
    Task<BaseResult> CreateSchedule(ScheduleCreateInfo info);
    Task<BaseResult> UpdateSchedule(int id,ScheduleUpdateInfo info);
    Task<BaseResult> DeleteSchedule(int id);
}
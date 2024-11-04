namespace GymSphere.Services.ScheduleService;

public sealed class ScheduleService(DataContext.DataContext context):IScheduleService
{
    public async Task<Result<PagedResponse<IEnumerable<ScheduleReadInfo>>>> GetSchedules(ScheduleFilter filter)
    {
        IQueryable<Schedule> bookings = context.Schedules;

        if (filter.StartTime != null)
            bookings = bookings.Where(x => x.StartTime == filter.StartTime);
        if (filter.EndTime != null)
            bookings = bookings.Where(x => x.EndTime == filter.EndTime);
        if (filter.TrainerId != null)
            bookings = bookings.Where(x => x.TrainerId == filter.TrainerId);
        if (filter.GymId != null)
            bookings = bookings.Where(x => x.GymId == filter.GymId);

        int count = await bookings.CountAsync();

        IQueryable<ScheduleReadInfo> result = bookings
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<ScheduleReadInfo>> response = PagedResponse<IEnumerable<ScheduleReadInfo>>
            .Create(filter.PageNumber, filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<ScheduleReadInfo>>>.Success(response);
    }

    public async Task<Result<ScheduleReadInfo>> GetScheduleById(int id)
    {
        Schedule? result = await context.Schedules.FirstOrDefaultAsync(x => x.Id == id);

        return result is null
            ? Result<ScheduleReadInfo>.Failure(Error.NotFound())
            : Result<ScheduleReadInfo>.Success(result.ToReadInfo());
    }

    public async Task<BaseResult> CreateSchedule(ScheduleCreateInfo info)
    {
        if (info==null)
            return BaseResult.Failure(Error.NotFound());
        await context.Schedules.AddAsync(info.ToSchedule());
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not saved !!!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> UpdateSchedule(int id, ScheduleUpdateInfo info)
    {
        Schedule? existingSchedule = await context.Schedules.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (existingSchedule is null)
            return BaseResult.Failure(Error.NotFound());

        existingSchedule.ToUpdatedSchedule(info);
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not updated!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> DeleteSchedule(int id)
    {
        Schedule? existingSchedule = await context.Schedules.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (existingSchedule is null)
            return BaseResult.Failure(Error.NotFound());

        existingSchedule.ToDeletedSchedule();
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not deleted!!"))
            : BaseResult.Success();
    }
}
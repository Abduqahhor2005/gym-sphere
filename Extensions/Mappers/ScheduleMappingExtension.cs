namespace GymSphere.Extensions.Mappers;

public static class ScheduleMappingExtensions
{
    public static ScheduleReadInfo ToReadInfo(this Schedule role)
    {
        return new()
        {
            Id = role.Id,
            ScheduleBaseInfo = new()
            {
                StartTime = role.StartTime,
                EndTime = role.EndTime,
                TrainerId = role.TrainerId,
                GymId = role.GymId
            }
        };
    }

    public static Schedule ToSchedule(this ScheduleCreateInfo createInfo)
    {
        return new()
        {
            StartTime = createInfo.ScheduleBaseInfo.StartTime,
            EndTime = createInfo.ScheduleBaseInfo.EndTime,
            TrainerId = createInfo.ScheduleBaseInfo.TrainerId,
            GymId = createInfo.ScheduleBaseInfo.GymId,
        };
    }

    public static Schedule ToUpdatedSchedule(this Schedule role, ScheduleUpdateInfo updateInfo)
    {
        role.Version++;
        role.UpdatedAt = DateTime.UtcNow;
        role.StartTime = updateInfo.ScheduleBaseInfo.StartTime;
        role.EndTime = updateInfo.ScheduleBaseInfo.EndTime;
        role.TrainerId = updateInfo.ScheduleBaseInfo.TrainerId;
        role.GymId = updateInfo.ScheduleBaseInfo.GymId;
        return role;
    }

    public static Schedule ToDeletedSchedule(this Schedule role)
    {
        role.IsDeleted = true;
        role.DeletedAt = DateTime.UtcNow;
        role.UpdatedAt = DateTime.UtcNow;
        role.Version++;
        return role;
    }
}
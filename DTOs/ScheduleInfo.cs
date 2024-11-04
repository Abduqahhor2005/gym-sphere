namespace GymSphere.DTOs;

public readonly record struct ScheduleBaseInfo(
    DateTimeOffset StartTime,
    DateTimeOffset EndTime,
    int TrainerId,
    int GymId);

public readonly record struct ScheduleReadInfo(
    int Id,
    ScheduleBaseInfo ScheduleBaseInfo);

public readonly record struct ScheduleCreateInfo(
    ScheduleBaseInfo ScheduleBaseInfo);

public readonly record struct ScheduleUpdateInfo(
    ScheduleBaseInfo ScheduleBaseInfo);
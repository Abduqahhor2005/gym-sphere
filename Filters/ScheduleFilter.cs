namespace GymSphere.Filters;

public record ScheduleFilter(
    DateTimeOffset? StartTime,
    DateTimeOffset? EndTime,
    int? TrainerId,
    int? GymId):BaseFilter;
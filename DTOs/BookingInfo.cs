namespace GymSphere.DTOs;

public readonly record struct BookingBaseInfo(
    double Price,
    DateTimeOffset BookingDate,
    int MemberId,
    int ScheduleId);

public readonly record struct BookingReadInfo(
    int Id,
    BookingBaseInfo BookingBaseInfo);

public readonly record struct BookingCreateInfo(
    BookingBaseInfo BookingBaseInfo);

public readonly record struct BookingUpdateInfo(
    BookingBaseInfo BookingBaseInfo);
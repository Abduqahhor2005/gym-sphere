namespace GymSphere.Extensions.Mappers;

public static class BookingMappingExtensions
{
    public static BookingReadInfo ToReadInfo(this Booking role)
    {
        return new()
        {
            Id = role.Id,
            BookingBaseInfo = new()
            {
                Price = role.Price,
                BookingDate = role.BookingDate,
                MemberId = role.MemberId,
                ScheduleId = role.ScheduleId
            }
        };
    }

    public static Booking ToBooking(this BookingCreateInfo createInfo)
    {
        return new()
        {
            Price = createInfo.BookingBaseInfo.Price,
            BookingDate = createInfo.BookingBaseInfo.BookingDate,
            MemberId = createInfo.BookingBaseInfo.MemberId,
            ScheduleId = createInfo.BookingBaseInfo.ScheduleId
        };
    }

    public static Booking ToUpdatedBooking(this Booking role, BookingUpdateInfo updateInfo)
    {
        role.Version++;
        role.UpdatedAt = DateTime.UtcNow;
        role.Price = updateInfo.BookingBaseInfo.Price;
        role.BookingDate = updateInfo.BookingBaseInfo.BookingDate;
        role.MemberId = updateInfo.BookingBaseInfo.MemberId;
        role.ScheduleId = updateInfo.BookingBaseInfo.ScheduleId;
        return role;
    }

    public static Booking ToDeletedBooking(this Booking role)
    {
        role.IsDeleted = true;
        role.DeletedAt = DateTime.UtcNow;
        role.UpdatedAt = DateTime.UtcNow;
        role.Version++;
        return role;
    }
}
namespace GymSphere.Services.BookingService;

public sealed class BookingService(DataContext.DataContext context):IBookingService
{
    public async Task<Result<PagedResponse<IEnumerable<BookingReadInfo>>>> GetBookings(BookingFilter filter)
    {
        IQueryable<Booking> bookings = context.Bookings;

        if (filter.Price != null)
            bookings = bookings.Where(x => x.Price == filter.Price);
        if (filter.BookingDate != null)
            bookings = bookings.Where(x => x.BookingDate == filter.BookingDate);
        if (filter.MemberId != null)
            bookings = bookings.Where(x => x.MemberId == filter.MemberId);
        if (filter.ScheduleId != null)
            bookings = bookings.Where(x => x.ScheduleId == filter.ScheduleId);

        int count = await bookings.CountAsync();

        IQueryable<BookingReadInfo> result = bookings
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<BookingReadInfo>> response = PagedResponse<IEnumerable<BookingReadInfo>>
            .Create(filter.PageNumber, filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<BookingReadInfo>>>.Success(response);
    }

    public async Task<Result<BookingReadInfo>> GetBookingById(int id)
    {
        Booking? result = await context.Bookings.FirstOrDefaultAsync(x => x.Id == id);

        return result is null
            ? Result<BookingReadInfo>.Failure(Error.NotFound())
            : Result<BookingReadInfo>.Success(result.ToReadInfo());
    }

    public async Task<BaseResult> CreateBooking(BookingCreateInfo info)
    {
        if (info==null)
            return BaseResult.Failure(Error.NotFound());
        await context.Bookings.AddAsync(info.ToBooking());
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not saved !!!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> UpdateBooking(int id, BookingUpdateInfo info)
    {
        Booking? existingBooking = await context.Bookings.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (existingBooking is null)
            return BaseResult.Failure(Error.NotFound());

        existingBooking.ToUpdatedBooking(info);
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not updated!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> DeleteBooking(int id)
    {
        Booking? existingBooking = await context.Bookings.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (existingBooking is null)
            return BaseResult.Failure(Error.NotFound());

        existingBooking.ToDeletedBooking();
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not deleted!!"))
            : BaseResult.Success();
    }
}
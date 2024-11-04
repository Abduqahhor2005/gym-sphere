namespace GymSphere.Services.BookingService;

public interface IBookingService
{
    Task<Result<PagedResponse<IEnumerable<BookingReadInfo>>>> GetBookings(BookingFilter filter);
    Task<Result<BookingReadInfo>> GetBookingById(int id);
    Task<BaseResult> CreateBooking(BookingCreateInfo info);
    Task<BaseResult> UpdateBooking(int id,BookingUpdateInfo info);
    Task<BaseResult> DeleteBooking(int id);
}
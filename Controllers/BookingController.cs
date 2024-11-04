namespace GymSphere.Controllers;

[Route("/api/booking")]
public sealed class BookingController(IBookingService bookingService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]BookingFilter filter)
        => (await bookingService.GetBookings(filter)).ToActionResult();


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute]int id)
        => (await bookingService.GetBookingById(id)).ToActionResult();


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookingCreateInfo entity)
        => (await bookingService.CreateBooking(entity)).ToActionResult();

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute]int id,[FromBody] BookingUpdateInfo entity)
        => (await bookingService.UpdateBooking(id,entity)).ToActionResult();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
        => (await bookingService.DeleteBooking(id)).ToActionResult();
}
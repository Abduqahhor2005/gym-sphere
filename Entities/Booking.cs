namespace GymSphere.Entities;

public sealed class Booking:BaseEntity
{
    public double Price { get; set; }
    public DateTimeOffset BookingDate { get; set; }
    
    public int MemberId { get; set; }
    public Member Member { get; set; } = null!;

    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; } = null!;
}
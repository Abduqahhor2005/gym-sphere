namespace GymSphere.Entities;

public sealed class Schedule:BaseEntity
{
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    
    public int TrainerId { get; set; }
    public Trainer Trainer { get; set; } = null!;
    
    public int GymId { get; set; }
    public Gym Gym { get; set; } = null!;
    
    public ICollection<Booking> Bookings { get; set; } = [];
}
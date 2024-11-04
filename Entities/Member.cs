namespace GymSphere.Entities;

public sealed class Member:Person
{
    public DateTimeOffset RegistrationDate  { get; set; }
    public ICollection<Booking> Bookings { get; set; } = [];
}
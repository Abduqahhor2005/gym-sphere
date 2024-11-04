namespace GymSphere.Entities;

public sealed class Gym:BaseEntity
{
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public ICollection<Schedule> Schedules { get; set; } = [];
}
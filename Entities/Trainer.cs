namespace GymSphere.Entities;

public sealed class Trainer:Person
{
    public int ExperienceYears { get; set; }
    public string Specialization { get; set; } = null!;

    public ICollection<Schedule> Schedules { get; set; } = [];
}
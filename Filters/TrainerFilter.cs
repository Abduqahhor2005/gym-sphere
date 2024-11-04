namespace GymSphere.Filters;

public record TrainerFilter(
    string? FullName,
    int? Age,
    string? Email,
    string? PhoneNumber,
    string? Address,
    int? ExperienceYears,
    string? Specialization) : BaseFilter;
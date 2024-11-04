namespace GymSphere.DTOs;

public readonly record struct TrainerBaseInfo(
    string FullName,
    int Age,
    string Email,
    string PhoneNumber,
    string Address,
    int ExperienceYears,
    string Specialization);

public readonly record struct TrainerReadInfo(
    int Id,
    TrainerBaseInfo TrainerBaseInfo);

public readonly record struct TrainerCreateInfo(
    TrainerBaseInfo TrainerBaseInfo);

public readonly record struct TrainerUpdateInfo(
    TrainerBaseInfo TrainerBaseInfo);
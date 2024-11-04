namespace GymSphere.DTOs;

public readonly record struct GymBaseInfo(
    string Name,
    string Location);

public readonly record struct GymReadInfo(
    int Id,
    GymBaseInfo GymBaseInfo);

public readonly record struct GymCreateInfo(
    GymBaseInfo GymBaseInfo);

public readonly record struct GymUpdateInfo(
    GymBaseInfo GymBaseInfo);
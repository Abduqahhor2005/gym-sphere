namespace GymSphere.DTOs;

public readonly record struct MemberBaseInfo(
    string FullName,
    int Age,
    string Email,
    string PhoneNumber,
    string Address,
    DateTimeOffset RegistrationDate);

public readonly record struct MemberReadInfo(
    int Id,
    MemberBaseInfo MemberBaseInfo);

public readonly record struct MemberCreateInfo(
    MemberBaseInfo MemberBaseInfo);

public readonly record struct MemberUpdateInfo(
    MemberBaseInfo MemberBaseInfo);
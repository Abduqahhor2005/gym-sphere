namespace GymSphere.Extensions.Mappers;

public static class MemberMappingExtensions
{
    public static MemberReadInfo ToReadInfo(this Member role)
    {
        return new()
        {
            Id = role.Id,
            MemberBaseInfo = new()
            {
                FullName = role.FullName,
                Age = role.Age,
                Email = role.Email,
                PhoneNumber = role.PhoneNumber,
                Address = role.Address,
                RegistrationDate = role.RegistrationDate
            }
        };
    }

    public static Member ToMember(this MemberCreateInfo createInfo)
    {
        return new()
        {
            FullName = createInfo.MemberBaseInfo.FullName,
            Age = createInfo.MemberBaseInfo.Age,
            Email = createInfo.MemberBaseInfo.Email,
            PhoneNumber = createInfo.MemberBaseInfo.PhoneNumber,
            Address = createInfo.MemberBaseInfo.Address,
            RegistrationDate = createInfo.MemberBaseInfo.RegistrationDate
        };
    }

    public static Member ToUpdatedMember(this Member role, MemberUpdateInfo updateInfo)
    {
        role.Version++;
        role.UpdatedAt = DateTime.UtcNow;
        role.FullName = updateInfo.MemberBaseInfo.FullName;
        role.Age = updateInfo.MemberBaseInfo.Age;
        role.Email = updateInfo.MemberBaseInfo.Email;
        role.PhoneNumber = updateInfo.MemberBaseInfo.PhoneNumber;
        role.Address = updateInfo.MemberBaseInfo.Address;
        role.RegistrationDate = updateInfo.MemberBaseInfo.RegistrationDate;
        return role;
    }

    public static Member ToDeletedMember(this Member role)
    {
        role.IsDeleted = true;
        role.DeletedAt = DateTime.UtcNow;
        role.UpdatedAt = DateTime.UtcNow;
        role.Version++;
        return role;
    }
}
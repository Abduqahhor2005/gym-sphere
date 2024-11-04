namespace GymSphere.Extensions.Mappers;

public static class GymMappingExtensions
{
    public static GymReadInfo ToReadInfo(this Gym role)
    {
        return new()
        {
            Id = role.Id,
            GymBaseInfo = new()
            {
                Name = role.Name,
                Location = role.Location
            }
        };
    }

    public static Gym ToGym(this GymCreateInfo createInfo)
    {
        return new()
        {
            Name = createInfo.GymBaseInfo.Name,
            Location = createInfo.GymBaseInfo.Location
        };
    }

    public static Gym ToUpdatedGym(this Gym role, GymUpdateInfo updateInfo)
    {
        role.Version++;
        role.UpdatedAt = DateTime.UtcNow;
        role.Name = updateInfo.GymBaseInfo.Name;
        role.Location = updateInfo.GymBaseInfo.Location;
        return role;
    }

    public static Gym ToDeletedGym(this Gym role)
    {
        role.IsDeleted = true;
        role.DeletedAt = DateTime.UtcNow;
        role.UpdatedAt = DateTime.UtcNow;
        role.Version++;
        return role;
    }
}
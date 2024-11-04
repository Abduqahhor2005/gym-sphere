namespace GymSphere.Extensions.Mappers;

public static class TrainerMappingExtensions
{
    public static TrainerReadInfo ToReadInfo(this Trainer role)
    {
        return new()
        {
            Id = role.Id,
            TrainerBaseInfo = new()
            {
                FullName = role.FullName,
                Age = role.Age,
                Email = role.Email,
                PhoneNumber = role.PhoneNumber,
                Address = role.Address,
                ExperienceYears = role.ExperienceYears,
                Specialization = role.Specialization
            }
        };
    }

    public static Trainer ToTrainer(this TrainerCreateInfo createInfo)
    {
        return new()
        {
            FullName = createInfo.TrainerBaseInfo.FullName,
            Age = createInfo.TrainerBaseInfo.Age,
            Email = createInfo.TrainerBaseInfo.Email,
            PhoneNumber = createInfo.TrainerBaseInfo.PhoneNumber,
            Address = createInfo.TrainerBaseInfo.Address,
            ExperienceYears = createInfo.TrainerBaseInfo.ExperienceYears,
            Specialization = createInfo.TrainerBaseInfo.Specialization
        };
    }

    public static Trainer ToUpdatedTrainer(this Trainer role, TrainerUpdateInfo updateInfo)
    {
        role.Version++;
        role.UpdatedAt = DateTime.UtcNow;
        role.FullName = updateInfo.TrainerBaseInfo.FullName;
        role.Age = updateInfo.TrainerBaseInfo.Age;
        role.Email = updateInfo.TrainerBaseInfo.Email;
        role.PhoneNumber = updateInfo.TrainerBaseInfo.PhoneNumber;
        role.Address = updateInfo.TrainerBaseInfo.Address;
        role.ExperienceYears = updateInfo.TrainerBaseInfo.ExperienceYears;
        role.Specialization = updateInfo.TrainerBaseInfo.Specialization;
        return role;
    }

    public static Trainer ToDeletedTrainer(this Trainer role)
    {
        role.IsDeleted = true;
        role.DeletedAt = DateTime.UtcNow;
        role.UpdatedAt = DateTime.UtcNow;
        role.Version++;
        return role;
    }
}
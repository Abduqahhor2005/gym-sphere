namespace GymSphere.Entities.Configurations;

public sealed class GymConfiguration : IEntityTypeConfiguration<Gym>
{
    public void Configure(EntityTypeBuilder<Gym> builder)
    {
        builder
            .HasMany(g => g.Schedules)
            .WithOne(s => s.Gym)
            .HasForeignKey(s => s.GymId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
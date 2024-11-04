namespace GymSphere.Entities.Configurations;

public sealed class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder
            .HasMany(s => s.Bookings)
            .WithOne(b => b.Schedule)
            .HasForeignKey(b => b.ScheduleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
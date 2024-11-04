namespace GymSphere.Entities.Configurations;

public sealed class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder
            .HasMany(t => t.Schedules)
            .WithOne(s => s.Trainer)
            .HasForeignKey(s => s.TrainerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
namespace GymSphere.Entities.Configurations;

public sealed class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder
            .HasMany(m => m.Bookings)
            .WithOne(b => b.Member)
            .HasForeignKey(b => b.MemberId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
namespace GymSphere.DataContext;

public sealed class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Gym> Gyms { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        modelBuilder.FilterSoftDeletedProperties();
        base.OnModelCreating(modelBuilder);
    }
}
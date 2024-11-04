namespace GymSphere.Extensions.DI;

public static class RegisterServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITrainerService, TrainerService>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IScheduleService, ScheduleService>();
        services.AddScoped<IGymService, GymService>();
        services.AddScoped<IBookingService, BookingService>();
        return services;
    }
}
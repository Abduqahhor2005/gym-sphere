namespace GymSphere.Services.TrainerService;

public sealed class TrainerService(DataContext.DataContext context):ITrainerService
{
    public async Task<Result<PagedResponse<IEnumerable<TrainerReadInfo>>>> GetTrainers(TrainerFilter filter)
    {
        IQueryable<Trainer> bookings = context.Trainers;

        if (filter.FullName is not null)
            bookings = bookings.Where(x => x.FullName.ToLower().Contains(filter.FullName.ToLower()));
        if (filter.Age != null)
            bookings = bookings.Where(x => x.Age == filter.Age);
        if (filter.Email is not null)
            bookings = bookings.Where(x => x.Email.ToLower().Contains(filter.Email.ToLower()));
        if (filter.PhoneNumber is not null)
            bookings = bookings.Where(x => x.PhoneNumber.ToLower().Contains(filter.PhoneNumber.ToLower()));
        if (filter.Address is not null)
            bookings = bookings.Where(x => x.Address.ToLower().Contains(filter.Address.ToLower()));
        if (filter.ExperienceYears != null)
            bookings = bookings.Where(x => x.ExperienceYears == filter.ExperienceYears);
        if (filter.Specialization is not null)
            bookings = bookings.Where(x => x.Specialization.ToLower().Contains(filter.Specialization.ToLower()));

        int count = await bookings.CountAsync();

        IQueryable<TrainerReadInfo> result = bookings
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<TrainerReadInfo>> response = PagedResponse<IEnumerable<TrainerReadInfo>>
            .Create(filter.PageNumber, filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<TrainerReadInfo>>>.Success(response);
    }

    public async Task<Result<TrainerReadInfo>> GetTrainerById(int id)
    {
        Trainer? result = await context.Trainers.FirstOrDefaultAsync(x => x.Id == id);

        return result is null
            ? Result<TrainerReadInfo>.Failure(Error.NotFound())
            : Result<TrainerReadInfo>.Success(result.ToReadInfo());
    }

    public async Task<BaseResult> CreateTrainer(TrainerCreateInfo info)
    {
        if (info==null)
            return BaseResult.Failure(Error.NotFound());
        await context.Trainers.AddAsync(info.ToTrainer());
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not saved !!!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> UpdateTrainer(int id, TrainerUpdateInfo info)
    {
        Trainer? existingTrainer = await context.Trainers.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (existingTrainer is null)
            return BaseResult.Failure(Error.NotFound());

        existingTrainer.ToUpdatedTrainer(info);
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not updated!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> DeleteTrainer(int id)
    {
        Trainer? existingTrainer = await context.Trainers.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (existingTrainer is null)
            return BaseResult.Failure(Error.NotFound());

        existingTrainer.ToDeletedTrainer();
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not deleted!!"))
            : BaseResult.Success();
    }
}
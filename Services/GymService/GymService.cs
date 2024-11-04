namespace GymSphere.Services.GymService;

public sealed class GymService(DataContext.DataContext context):IGymService
{
    public async Task<Result<PagedResponse<IEnumerable<GymReadInfo>>>> GetGyms(GymFilter filter)
    {
        IQueryable<Gym> gyms = context.Gyms;

        if (filter.Name is not null)
            gyms = gyms.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
        if (filter.Location is not null)
            gyms = gyms.Where(x => x.Location.ToLower().Contains(filter.Location.ToLower()));

        int count = await gyms.CountAsync();

        IQueryable<GymReadInfo> result = gyms
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<GymReadInfo>> response = PagedResponse<IEnumerable<GymReadInfo>>
            .Create(filter.PageNumber, filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<GymReadInfo>>>.Success(response);
    }

    public async Task<Result<GymReadInfo>> GetGymById(int id)
    {
        Gym? result = await context.Gyms.FirstOrDefaultAsync(x => x.Id == id);

        return result is null
            ? Result<GymReadInfo>.Failure(Error.NotFound())
            : Result<GymReadInfo>.Success(result.ToReadInfo());
    }

    public async Task<BaseResult> CreateGym(GymCreateInfo info)
    {
        if (info==null)
            return BaseResult.Failure(Error.NotFound());
        await context.Gyms.AddAsync(info.ToGym());
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not saved !!!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> UpdateGym(int id, GymUpdateInfo info)
    {
        Gym? existingGym = await context.Gyms.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (existingGym is null)
            return BaseResult.Failure(Error.NotFound());

        existingGym.ToUpdatedGym(info);
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not updated!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> DeleteGym(int id)
    {
        Gym? existingGym = await context.Gyms.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (existingGym is null)
            return BaseResult.Failure(Error.NotFound());

        existingGym.ToDeletedGym();
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not deleted!!"))
            : BaseResult.Success();
    }
}
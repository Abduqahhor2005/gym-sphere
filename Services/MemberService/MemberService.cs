namespace GymSphere.Services.MemberService;

public sealed class MemberService(DataContext.DataContext context):IMemberService
{
    public async Task<Result<PagedResponse<IEnumerable<MemberReadInfo>>>> GetMembers(MemberFilter filter)
    {
        IQueryable<Member> bookings = context.Members;

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
        if (filter.RegistrationDate != null)
            bookings = bookings.Where(x => x.RegistrationDate == filter.RegistrationDate);

        int count = await bookings.CountAsync();

        IQueryable<MemberReadInfo> result = bookings
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<MemberReadInfo>> response = PagedResponse<IEnumerable<MemberReadInfo>>
            .Create(filter.PageNumber, filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<MemberReadInfo>>>.Success(response);
    }

    public async Task<Result<MemberReadInfo>> GetMemberById(int id)
    {
        Member? result = await context.Members.FirstOrDefaultAsync(x => x.Id == id);

        return result is null
            ? Result<MemberReadInfo>.Failure(Error.NotFound())
            : Result<MemberReadInfo>.Success(result.ToReadInfo());
    }

    public async Task<BaseResult> CreateMember(MemberCreateInfo info)
    {
        if (info==null)
            return BaseResult.Failure(Error.NotFound());
        await context.Members.AddAsync(info.ToMember());
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not saved !!!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> UpdateMember(int id, MemberUpdateInfo info)
    {
        Member? existingMember = await context.Members.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (existingMember is null)
            return BaseResult.Failure(Error.NotFound());

        existingMember.ToUpdatedMember(info);
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not updated!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> DeleteMember(int id)
    {
        Member? existingMember = await context.Members.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (existingMember is null)
            return BaseResult.Failure(Error.NotFound());

        existingMember.ToDeletedMember();
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not deleted!!"))
            : BaseResult.Success();
    }
}
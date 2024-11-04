namespace GymSphere.Services.GymService;

public interface IGymService
{
    Task<Result<PagedResponse<IEnumerable<GymReadInfo>>>> GetGyms(GymFilter filter);
    Task<Result<GymReadInfo>> GetGymById(int id);
    Task<BaseResult> CreateGym(GymCreateInfo info);
    Task<BaseResult> UpdateGym(int id,GymUpdateInfo info);
    Task<BaseResult> DeleteGym(int id);
}
namespace GymSphere.Controllers;

[Route("/api/gym")]
public sealed class GymController(IGymService gymService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GymFilter filter)
        => (await gymService.GetGyms(filter)).ToActionResult();


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute]int id)
        => (await gymService.GetGymById(id)).ToActionResult();


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GymCreateInfo entity)
        => (await gymService.CreateGym(entity)).ToActionResult();

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute]int id,[FromBody] GymUpdateInfo entity)
        => (await gymService.UpdateGym(id,entity)).ToActionResult();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
        => (await gymService.DeleteGym(id)).ToActionResult();
}
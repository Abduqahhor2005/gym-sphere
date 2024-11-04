namespace GymSphere.Controllers;

[Route("/api/trainer")]
public sealed class TrainerController(ITrainerService trainerService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] TrainerFilter filter)
        => (await trainerService.GetTrainers(filter)).ToActionResult();


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute]int id)
        => (await trainerService.GetTrainerById(id)).ToActionResult();


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TrainerCreateInfo entity)
        => (await trainerService.CreateTrainer(entity)).ToActionResult();

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute]int id,[FromBody] TrainerUpdateInfo entity)
        => (await trainerService.UpdateTrainer(id,entity)).ToActionResult();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
        => (await trainerService.DeleteTrainer(id)).ToActionResult();
}
namespace GymSphere.Controllers;

[Route("/api/schedule")]
public sealed class ScheduleController(IScheduleService scheduleService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ScheduleFilter filter)
        => (await scheduleService.GetSchedules(filter)).ToActionResult();


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute]int id)
        => (await scheduleService.GetScheduleById(id)).ToActionResult();


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ScheduleCreateInfo entity)
        => (await scheduleService.CreateSchedule(entity)).ToActionResult();

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute]int id,[FromBody] ScheduleUpdateInfo entity)
        => (await scheduleService.UpdateSchedule(id,entity)).ToActionResult();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
        => (await scheduleService.DeleteSchedule(id)).ToActionResult();
}
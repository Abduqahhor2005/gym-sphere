namespace GymSphere.Controllers;

[Route("/api/member")]
public sealed class MemberController(IMemberService memberService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] MemberFilter filter)
        => (await memberService.GetMembers(filter)).ToActionResult();


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute]int id)
        => (await memberService.GetMemberById(id)).ToActionResult();


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MemberCreateInfo entity)
        => (await memberService.CreateMember(entity)).ToActionResult();

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute]int id,[FromBody] MemberUpdateInfo entity)
        => (await memberService.UpdateMember(id,entity)).ToActionResult();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
        => (await memberService.DeleteMember(id)).ToActionResult();
}
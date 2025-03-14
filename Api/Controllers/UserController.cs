using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("usuarios")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost("")]
    public async Task<ActionResult<User>> Create(User user)
    {
        var createdUser = await _service.Create(user);
        return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(Guid id)
    {
        var user = await _service.GetById(id);
        return user != null ? Ok(user) : NotFound();
    }

    [HttpPut]
    public async Task<ActionResult<User>> Update(User user)
    {
        var updatedUser = await _service.Update(user);
        return updatedUser != null ? Ok(updatedUser) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<User>> Delete(Guid id)
    {
        var deletedUser = await _service.Delete(id);
        return deletedUser != null ? Ok(deletedUser) : NotFound();
    }
}
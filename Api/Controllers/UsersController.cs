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

    /// <summary>
    /// Creates a new User
    /// </summary>
    /// <param name="user">The user details to create.</param>
    /// <returns>The newly created user.</returns>
    /// <response code="200">Returns the created user.</response>
    /// <response code="400">If the user data is invalid or missing.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<User>> Create([FromBody] CreateUserDto userDto)
    {
        var user = new User
        {
            Name = userDto.Name,
            Email = userDto.Email,
        };
        var createdUser = await _service.Create(user);
        return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
    }

    /// <summary>
    /// Returns a user.
    /// </summary>
    /// <param name="id">The user id.</param>
    /// <returns>A user.</returns>
    /// <response code="200">Returns a user.</response>
    /// <response code="404">If the user data is invalid or missing.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<User>> GetById(Guid id)
    {
        var user = await _service.GetById(id);
        return user != null ? Ok(user) : NotFound();
    }

    /// <summary>
    /// Updates an existing User.
    /// </summary>
    /// <param name="user">The user details to update.</param>
    /// <returns>The newly updated user.</returns>
    /// <response code="200">Returns the updated user.</response>
    /// <response code="404">If the user data is invalid or missing.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<User>> Update([FromBody] UpdateUserDto userDto)
    {
        var user = new User
        {
            Email = userDto.Email,
            Name = userDto.Name,
        };
        var updatedUser = await _service.Update(user);
        return updatedUser != null ? Ok(updatedUser) : NotFound();
    }

    /// <summary>
    /// Deletes an user
    /// </summary>
    /// <param name="id">the user id.</param>
    /// <returns>The newly deleted user</returns>
    /// <response code="200">Returns the deleted user.</response>
    /// <response code="404">If the user data is invalid or missing.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<User>> Delete(Guid id)
    {
        var deletedUser = await _service.Delete(id);
        return deletedUser != null ? Ok(deletedUser) : NotFound();
    }
}
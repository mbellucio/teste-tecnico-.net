using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public AuthController(IUserService userService, ITokenService tokenService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        // This is a simple example - in reality, you'd validate credentials
        var user = await _userService.GetById(loginDto.UserId);
        if (user == null)
            return Unauthorized("Invalid credentials");

        var token = _tokenService.GenerateToken(user.Id.ToString());
        return Ok(new { Token = token });
    }
}

public class LoginDto
{
    public Guid UserId { get; set; }
    // Add password or other credentials as needed
}
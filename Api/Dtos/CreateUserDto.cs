/// <summary>
/// Data required to create a new user.
/// </summary>
public class CreateUserDto
{
    /// <summary>
    /// The name of the User.
    /// </summary>
    /// <example>Test User</example>
    required public string Name { get; set; }

    /// <summary>
    /// The email of the User.
    /// </summary>
    /// <example>100.00</example>
    required public string Email { get; set; }
}
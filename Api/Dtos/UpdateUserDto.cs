/// <summary>
/// Data required to update a new user.
/// </summary>
public class UpdateUserDto
{
    /// <summary>
    /// The name of the User.
    /// </summary>
    /// <example>Test User</example>
    public string Name { get; set; }

    /// <summary>
    /// The email of the User.
    /// </summary>
    /// <example>100.00</example>
    public string Email { get; set; }
}
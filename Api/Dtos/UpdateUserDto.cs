/// <summary>
/// Data required to update an existing user. Only provided fields will be updated.
/// </summary>
public class UpdateUserDto
{
    /// <summary>
    /// The name of the user. Optional; if not provided, the existing value is retained.
    /// </summary>
    /// <example>test user</example>
    public string? Name { get; set; }

    /// <summary>
    /// The email of the user. Optional; if not provided, the existing value is retained.
    /// </summary>
    /// <example>testuser@mail.com</example>
    public string? Email { get; set; }
}
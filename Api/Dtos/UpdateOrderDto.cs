/// <summary>
/// Data required to update an existing order. Only provided fields will be updated.
/// </summary>
public class UpdateOrderDto
{
    /// <summary>
    /// The description of the order. Optional; if not provided, the existing value is retained.
    /// </summary>
    /// <example>Test Order</example>
    public string? Description { get; set; }

    /// <summary>
    /// The monetary value of the order. Optional; if not provided, the existing value is retained.
    /// </summary>
    /// <example>100.00</example>
    public float? Value { get; set; }
}
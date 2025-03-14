/// <summary>
/// Data required to updaye a new order.
/// </summary>
public class UpdateOrderDto
{
    /// <summary>
    /// The description of the order.
    /// </summary>
    /// <example>Test Order</example>
    required public string Description { get; set; }

    /// <summary>
    /// The monetary value of the order.
    /// </summary>
    /// <example>100.00</example>
    required public float Value { get; set; }
}
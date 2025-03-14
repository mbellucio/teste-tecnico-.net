public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    required public string Description { get; set; }
    required public float Value { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public User User { get; set; }
}

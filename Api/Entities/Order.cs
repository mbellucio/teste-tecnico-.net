public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    required public string Description { get; set; }
    required public float Value { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public virtual User User { get; set; }
}

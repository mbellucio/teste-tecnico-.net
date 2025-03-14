public class User {
	public Guid Id { get; set; } = Guid.NewGuid();
	required public string Name { get; set; }
	required public string Email { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

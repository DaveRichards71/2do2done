namespace Domain;

public class User : BaseDomainModel
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Mobile { get; set; }

    public ICollection<User>? AssignsTasksTo { get; set; }
    public ICollection<User>? AcceptsTasksFrom { get; set; }

}

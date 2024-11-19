namespace Domain;

public class Task : BaseDomainModel
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required User Author { get; set; }
    public required User AssignedTo { get; set; }

    // For now, we will use a simple integer to represent the status of the task
    // 0 - Not Done (Default)
    // 1 - Done
    public required int Status { get; set; } = 0;
}

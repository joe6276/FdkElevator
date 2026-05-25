namespace FdkElevator.Models.Projects
{   

    public enum AllTaskStatus
    {
        NotStarted,
        InProgress,
        Completed,
        OnHold,
        Cancelled
    }
    public class ProjectTask
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public AllTaskStatus Status { get; set; } = AllTaskStatus.NotStarted;
        public string?  Notes { get; set; }

        public string? ImageURL { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}

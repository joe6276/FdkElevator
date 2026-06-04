namespace FdkElevator.Models.Projects
{
    public class ProjectDoc
    {
        public Guid Id { get; set; }

        public string Category { get; set; } = string.Empty;

        public string DocumentName { get; set; } = string.Empty;

        public string DocUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }

}

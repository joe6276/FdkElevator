namespace FdkElevator.DTOS.ProjectDTOS
{
    public class ProjectDocumentGroupDTO
    {
        public string Category { get; set; } = string.Empty;

        public List<ProjectDocumentDTO> Documents { get; set; } = new();
    }

    public class ProjectDocumentDTO
    {
        public Guid Id { get; set; }

        public string DocumentName { get; set; } = string.Empty;

        public string DocUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}

namespace FdkElevator.DTOS.ProjectDTOS
{
    public class AddProjectDocs
    {

        public string Category { get; set; } = string.Empty;
        public string DocumentName { get; set; } = string.Empty;

        public string DocUrl { get; set; } = string.Empty;

    }

    public class ProjectUnSignedDoc
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public string DocumentName { get; set; } = string.Empty;

        public string SignedDocumentUrl { get; set; } = string.Empty;

        public DateTime SignedDate { get; set; }
    }
}

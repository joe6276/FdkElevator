namespace FdkElevator.DTOS.ProjectDTOS
{
    public class AddProjectDTO
    {

  
        public Guid ClientId { get; set; }

        public Guid TenantId { get; set; }
    }

    public class ProjectClientDto
    {
        public Guid ProjectId { get; set; }
        public string ProjectCode { get; set; }
        public string ClientName { get; set; }
    }
}

namespace FdkElevator.DTOS.ProjectDTOS
{
    public class AddProjectDTO
    {

        public string ProjectCode { get; set; } = string.Empty;

        public Guid ClientId { get; set; }

        public Guid TenantId { get; set; }
    }
}

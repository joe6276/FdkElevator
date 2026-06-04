using FdkElevator.Models.Auth;
using FdkElevator.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.ProjectDTOS
{
    public class ProjectSignedDocDTO
    {
        public Guid ProjectId { get; set; }

        public string DocumentName { get; set; } = string.Empty;

        public string DocumentUrl { get; set; } = string.Empty;
        public Guid SignedBy { get; set; }
        public string? Remarks { get; set; }
    }
}

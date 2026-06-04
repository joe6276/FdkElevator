using FdkElevator.Models.Auth;
using FdkElevator.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.ProjectDTOS
{
    public class ProjectStageDTO
    {

        public string StageName { get; set; }

        public string StageCode { get; set; }

        public string Dependency { get; set; }
        public Guid UserId { get; set; }

        public Guid PhaseId { get; set; }
   
    }
}

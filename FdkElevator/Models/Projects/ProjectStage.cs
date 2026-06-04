using FdkElevator.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Projects
{
    public class ProjectStage
    {

        public Guid Id { get; set; }

        public string StageName { get; set; }

        public string StageCode { get; set; }

        public string Dependency { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }

        public Guid UserId { get; set; }

        public Guid PhaseId { get; set; }
        [ForeignKey("PhaseId")]
        public ProjectPhase ProjectPhase { get; set; }  

        public ICollection<ProjectTask> Tasks { get; set; }
    }
}

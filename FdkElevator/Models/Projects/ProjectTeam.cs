using FdkElevator.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Projects
{
    public class ProjectTeam
    {


        public Guid Id { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }

        public Guid  UserId { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}

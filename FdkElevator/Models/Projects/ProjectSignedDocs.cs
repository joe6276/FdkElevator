using FdkElevator.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Projects
{
    public class ProjectSignedDoc
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; } = null!;

        public string DocumentName { get; set; } = string.Empty;

        public string DocumentUrl { get; set; } = string.Empty;

        [ForeignKey("SignedBy")]
        public User user { get; set; } = null!;
        public Guid  SignedBy { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public DateTime SignedDate { get; set; } = DateTime.UtcNow;


        public string? Remarks { get; set; }
    }
}

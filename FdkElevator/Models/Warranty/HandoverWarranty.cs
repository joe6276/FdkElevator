using FdkElevator.Models.Projects;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Warranty
{
    public class HandoverWarranty
    {
        public Guid Id { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }

        public DateTime handoverDate { get; set; }

        public bool ClientTrainingCompleted { get; set; }

        public string HandoverCertificate { get; set; } = string.Empty;
        public string WarrantyTerms { get; set; } = string.Empty;
        public DateTime WarrantyStartDate { get; set; }
        public DateTime WarrantyEndDate { get; set; }
        public string ContactInformation { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}

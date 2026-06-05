namespace FdkElevator.DTOS.WarrantyDTO
{
    public class AddWarrantyDTO
    {
        public Guid ProjectId { get; set; }

        public DateTime handoverDate { get; set; }

        public bool ClientTrainingCompleted { get; set; }

        public string HandoverCertificate { get; set; } = string.Empty;
        public string WarrantyTerms { get; set; } = string.Empty;
        public DateTime WarrantyStartDate { get; set; }
        public DateTime WarrantyEndDate { get; set; }
        public string ContactInformation { get; set; } = string.Empty;
    }
}

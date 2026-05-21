using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Quotations
{   

    public enum QuotationStatus
    {
        Draft,
        PendingApproval,
        Approved,
        Sent,
        Revised,
        Accepted,
        Rejected,
        Expired
    }
    public class Quotation
    {
        public Guid Id { get; set; }
        [ForeignKey("LeadId")]
        public Lead Lead { get; set; }
        public Guid LeadId { get; set; }

        [ForeignKey("ClientId")]
        public User User { get; set; }

        public Guid ClientId { get; set; }

        public float Amount { get; set; }

        public float SubTotal { get; set; }

        public float Discount { get; set; }
        public ICollection<QuoteItem> Items { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public QuotationStatus Status { get; set; }

        public string QuotationNumber { get; set; }

        public int Revision { get; set; } = 1;

        public decimal InstallationCost { get; set; }

        public decimal FreightCost { get; set; }

        public decimal CustomsCost { get; set; }

        public decimal SubcontractorCost { get; set; }

        public string Warranty { get; set; }
        public string AmcOption { get; set; }

        public string PaymentTerms { get; set; }

        public int ValidityDays { get; set; }

        public LiftConfiguration configuration { get; set; }
    }
}

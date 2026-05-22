using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Quotations
{
    public class Revision
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
        public ICollection<QuoteItemRevision> Items { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public QuotationStatus Status { get; set; }

        public string RevisionNumber { get; set; }

        public decimal InstallationCost { get; set; }

        public decimal FreightCost { get; set; }

        public decimal CustomsCost { get; set; }

        public decimal SubcontractorCost { get; set; }

        public string Warranty { get; set; }
        public string AmcOption { get; set; }


        public Guid QuotationId { get; set; }
        [ForeignKey("QuotationId")]
        public Quotation Quotation { get; set; }
        public ICollection<QuotationPayment> Payment { get; set; }

        public int ValidityDays { get; set; }

        public LiftConfigurationRevision configuration { get; set; }

    }
}

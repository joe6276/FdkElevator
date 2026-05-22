using FdkElevator.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Quotations
{   

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed
    }
    public class QuotationPayment
    {

        public Guid Id { get; set; }

        [ForeignKey("ClientId")]
        public User user { get; set; }

        public Guid ClientId { get; set; }

        public decimal Amount { get; set; }

        public string? StripeSessionId { get; set; }

        public string?  PaymentIntentId { get;set; }

        public PaymentStatus Status { get; set; }= PaymentStatus.Pending;

        [ForeignKey("QuotationId")]
        public Quotation quotation { get; set; }
        public Guid? QuotationId { get; set; }

        [ForeignKey("RevisionId")]
        public Revision revision { get; set; }
        public Guid? RevisionId { get; set; }

        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

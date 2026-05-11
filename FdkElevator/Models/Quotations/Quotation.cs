using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Quotations
{
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
    }
}

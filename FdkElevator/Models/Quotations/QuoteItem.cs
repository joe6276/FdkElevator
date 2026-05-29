using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Quotations
{
    public class QuoteItem
    {

        public Guid Id { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public string? ImageURL { get; set; }

        public float Price { get; set; }

        [ForeignKey("QuotationId")]
        public Quotation Quotation { get; set; }


        public Guid QuotationId { get; set; }

    }
    public class QuoteItemRevision
    {

        public Guid Id { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public string? ImageURL { get; set; }

        public float Price { get; set; }

        public Revision revision { get; set; }


    }


}

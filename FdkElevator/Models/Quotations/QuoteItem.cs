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

        public Quotation Quotation { get; set; }
    }
}

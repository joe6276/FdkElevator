namespace FdkElevator.DTOS.PDFDTO
{
    public class QuotationDocument
    {
        public string QuotationRef { get; set; } = string.Empty;
        public DateTime QuotationDate { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ProductionType { get; set; } = string.Empty;
        public List<QuotationLineItem> LineItems { get; set; } = new();
        public decimal UsdToKesRate { get; set; }
        public int ValidityDays { get; set; } = 30;
        public string InstallationNote { get; set; } = string.Empty;
        public List<QuotationSpec> Specifications { get; set; } = new();
        public List<string> StandardFunctions { get; set; } = new();
    }

    public class QuotationLineItem
    {
        public string Product { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string BasicSpecs { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPriceUsd { get; set; }
        public decimal SubTotalKes { get; set; }
    }

    public class QuotationSpec
    {
        public int Number { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}

using FdkElevator.Models.Complaints;
using FdkElevator.Models.Orders;
using FdkElevator.Models.Projects;
using FdkElevator.Models.Quotations;

namespace FdkElevator.DTOS.FinanceDTO
{
    public class FinanceClass
    {

       public  List<QuotationPayment> quotationPayments { get; set; }

       public List<ServiceQuoteDto> serviceQuotes { get; set; }

        public List<RepairQuotation> repairQuotes { get; set; }


    }

    public class ServiceQuoteDto
    {
        public Guid Id { get; set; }
        public Guid JobId { get; set; }
        public string QuoteCode { get; set; }
        public ProjectMaintenanceQuoteStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime? ClientApprovedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class TenantOrderDto
    {
        public Guid OrderId { get; set; }
        public float Total { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }

        public ShippingAddressDto ShippingAddress { get; set; }

        public List<OrderItemDto> Items { get; set; } = new();
    }

    public class OrderItemDto
    {
        public Guid OrderItemId { get; set; }
        public Guid SupplierItemId { get; set; }

        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }

        public bool IsPaid { get; set; }

        public string? PaymentImageUrl { get; set; }
    }

    public class ShippingAddressDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostalCode { get; set; }
    }
}

using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Quotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.QuotationDTOS
{
    public class QuotationDTO
    {

        public Guid LeadId { get; set; }

        public Guid ClientId { get; set; }

        public float Discount { get; set; }

        public ICollection<QuotationItemDTO> Items { get; set; }

        public QuotationStatus Status { get; set; }

        public int Revision { get; set; } = 1;

        public decimal InstallationCost { get; set; }

        public decimal FreightCost { get; set; }

        public decimal CustomsCost { get; set; }

        public decimal SubcontractorCost { get; set; }

        public string Warranty { get; set; }
        public string AmcOption { get; set; }

        public string PaymentTerms { get; set; }

        public int ValidityDays { get; set; }

        public AddLiftConfiguration AddLiftConfiguration { get; set; } = new AddLiftConfiguration();
    }
    public class QuotationResponseDTO
    {

        public Guid LeadId { get; set; }

        public Guid ClientId { get; set; }
        public float Amount { get; set; }

        public float SubTotal { get; set; }

        public float Discount { get; set; }

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
        public ICollection<QuotationItemDTO> Items { get; set; }
        public AddLiftConfiguration config { get; set; } 
    }

}

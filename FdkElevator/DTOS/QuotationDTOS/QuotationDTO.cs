using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.QuotationDTOS
{
    public class QuotationDTO
    {

        public Guid LeadId { get; set; }

        public Guid ClientId { get; set; }

        public float Discount { get; set; }

        public ICollection<QuotationItemDTO> Items { get; set; }
    }
    public class QuotationResponseDTO
    {

        public Guid LeadId { get; set; }

        public Guid ClientId { get; set; }
        public float Amount { get; set; }

        public float SubTotal { get; set; }

        public float Discount { get; set; }

        public ICollection<QuotationItemDTO> Items { get; set; }
    }

}

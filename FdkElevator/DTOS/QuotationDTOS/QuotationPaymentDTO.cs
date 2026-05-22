using System.ComponentModel.DataAnnotations;

namespace FdkElevator.DTOS.QuotationDTOS
{
    public class QuotationPaymentDTO
    {
     
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}

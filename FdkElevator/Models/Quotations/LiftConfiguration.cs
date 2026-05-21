using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Quotations
{
    public class LiftConfiguration
    {

        public Guid Id { get; set; }

        public string LiftType { get; set; }

        public string DriveType { get; set; }

        public string Capacity { get; set; }
        public string Speed { get; set; }

        public string Stops { get; set; }
        public string DoorType { get; set; }

        public string ControllerType { get; set; }
        public string CabinFinish { get; set; }

        public Guid QuotationId { get; set; }
        [ForeignKey("QuotationId")]
        public Quotation quotation { get; set; }

    }
}

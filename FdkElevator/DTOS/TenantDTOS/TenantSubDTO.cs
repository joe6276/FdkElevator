using FdkElevator.Models.Tenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.TenantDTOS
{
    public class TenantSubDTO
    {


        public decimal Amount { get; set; }

        public Guid TenantId { get; set; }
    }
}

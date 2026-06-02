using FdkElevator.Models.Tenants;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.TenantDTOS
{
    public class ContractDTO
    {
        public Guid TenantId { get; set; }
        public string ContractName { get; set; } = string.Empty;

        public string ContractLink { get; set; } = string.Empty;

    }

    public class SignContractDTO
    {
        public Guid UserId { get; set; }

        public Guid ProjectId { get; set; }

        public string ContractLink { get; set; }
    }

}

using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Tenants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.DTOS.LeadDTOS
{

   
    public class AddActivityDTO
    {

        [Required]
        public Guid LeadId { get; set; }
        [Required]
        public Guid TenantId { get; set; }
        [Required]
        public ActivityType type { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Description { get; set; }
     
      
    }

    public class ResponseActivityDTO
    {

        public Guid Id { get; set; }
        public Guid LeadId { get; set; }

        public Guid TenantId { get; set; }

        public ActivityType type { get; set; }

        public Guid UserId { get; set; }

        public string Description { get; set; }

        public string Username { get; set; }

    }

    }

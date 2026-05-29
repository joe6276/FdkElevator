using FdkElevator.Models.Auth;
using FdkElevator.Models.Projects;
using FdkElevator.Models.Suppliers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Selection
{
    public class SelectedProduct
    {

        public Guid Id { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
        public bool isApproved { get; set; } = false;
        [ForeignKey("approvedBy")]
        public User user { get; set; }
        public Guid? approvedBy { get; set; }

        public ICollection<Product> Products { get; set; } 

    }

    public class Product
    {
        public Guid Id { get; set; }

        public Guid SupplierItemId { get; set; }

    }
}

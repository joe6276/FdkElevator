namespace FdkElevator.Models.Organization
{
    public class Organization
    {

        public Guid Id { get; set; }

        public float FreePlanCost { get; set; }

        public float BasicPlanCost{ get; set; }

        public float PremiumPlanCost { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

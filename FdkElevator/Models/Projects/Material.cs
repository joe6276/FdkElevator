namespace FdkElevator.Models.Projects
{
    public class Material
    {

        public Guid Id { get; set; }

        public string MaterialName { get; set; } = string.Empty;


        public Project Project { get; set; }

        public Guid ProjectId { get; set; }
    }
}

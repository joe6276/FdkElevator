using FdkElevator.Models.Projects;
using System.ComponentModel.DataAnnotations.Schema;

namespace FdkElevator.Models.Civil
{
    public class CivilReadiness
    {

        public Guid Id { get; set; }

        public  string Shaft { get; set; }

        public string Pit { get; set; }

        public string Overhead { get; set; }

        public string MachineRoom { get; set; }

        public string PowerSupply { get; set; }

        public string Access { get; set; }


        public string StorageArea { get; set; }

        public string SafetyBarricades { get; set; }

        public string LiftingPoints { get; set; }

        public string  BuildingReadiness { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}

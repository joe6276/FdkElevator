using FdkElevator.Models.Civil;

namespace FdkElevator.Services.IServices
{
    public interface ICivilReadiness
    {


        string  addCivilReadiness(CivilReadiness civilReadiness);

        CivilReadiness getCivilReadinessByProjectId(Guid projectId);

        string updateCivilReadiness(CivilReadiness civilReadiness);

        CivilReadiness getCivilReadinessById(Guid id);

        string markCivicReadiness(Guid projectId);
    }
}

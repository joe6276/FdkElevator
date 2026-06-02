using FdkElevator.DTOS.InstallationsDTO;
using FdkElevator.Models.Installations;

namespace FdkElevator.Services.IServices
{
    public interface  IInstallation
    {

        string addInstallation(Installation installation);

        List<Installation> getInstallationsByProjectId(Guid projectId);

        Installation getInstallation(Guid installationId);
        string updateInstallation(Installation installation);

        string completeInstallation(Guid installationId, string? notes);

        ProjectInstallationResponseDto GetTasksByProjectAsync(Guid projectId);
    }
}

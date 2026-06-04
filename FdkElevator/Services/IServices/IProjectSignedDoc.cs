using FdkElevator.DTOS.ProjectDTOS;
using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IProjectSignedDoc
    {

        string addProjectSignedDocs(ProjectSignedDoc projectSignedDoc);

        List<ProjectDoc> GetUnsignedDocumentsAsync(Guid projectId);
    }
}

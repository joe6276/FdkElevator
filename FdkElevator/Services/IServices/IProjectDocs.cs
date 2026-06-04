using FdkElevator.DTOS.ProjectDTOS;
using FdkElevator.Models.Projects;

namespace FdkElevator.Services.IServices
{
    public interface IProjectDocs
    {

        string addProjectDocs(ProjectDoc projectDoc);
        List<ProjectDocumentGroupDTO> GetDocumentsGroupedByCategory();

    }
}

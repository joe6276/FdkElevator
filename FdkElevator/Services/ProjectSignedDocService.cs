using FdkElevator.AppDbContext;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class ProjectSignedDocService : IProjectSignedDoc
    {   

        private readonly ApplicationDbContext _context;

        public ProjectSignedDocService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string addProjectSignedDocs(ProjectSignedDoc projectSignedDoc)
        {
          _context.projectSignedDocs.Add(projectSignedDoc);
            _context.SaveChanges();
            return "Project Signed Document added successfully";
        }

        public List<ProjectDoc> GetUnsignedDocumentsAsync(Guid projectId)
        {
            var signedDocumentNames =  _context.projectSignedDocs
                .Where(x => x.ProjectId == projectId)
                .Select(x => x.DocumentName)
                .ToList();

            return _context.projectDocs
                .Where(x => !signedDocumentNames.Contains(x.DocumentName))
                .ToList();
        }
    }
}

using FdkElevator.AppDbContext;
using FdkElevator.DTOS.ProjectDTOS;
using FdkElevator.Models.Projects;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class ProjectDocService : IProjectDocs
    {

        private readonly ApplicationDbContext _context;

        public ProjectDocService(ApplicationDbContext context)
        {
            _context= context;
        }
        public string addProjectDocs(ProjectDoc projectDoc)
        {
            _context.projectDocs.Add(projectDoc);
            _context.SaveChanges();
            return "Project document added successfully";
        }

        public  List<ProjectDocumentGroupDTO> GetDocumentsGroupedByCategory()
        {
            var documents = _context.projectDocs
                .OrderBy(x => x.Category)
                .ThenByDescending(x => x.CreatedAt)
                .ToList();

            var result = documents
                .GroupBy(x => x.Category)
                .Select(g => new ProjectDocumentGroupDTO
                {
                    Category = g.Key,
                    Documents = g.Select(d => new ProjectDocumentDTO
                    {
                        Id = d.Id,
                        DocumentName = d.DocumentName,
                        DocUrl = d.DocUrl,
                        CreatedAt = d.CreatedAt
                    }).ToList()
                })
                .ToList();

            return result;
        }
    }
}

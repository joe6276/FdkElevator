using FdkElevator.AppDbContext;
using FdkElevator.Models.Organization;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class OrganizationServices : IOrganization
    {
        private readonly ApplicationDbContext _context;
        public OrganizationServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public string addOrganization(Organization org)
        {
            _context.Organizations.Add(org);
            _context.SaveChanges();
            return "Organization added successfully!";
        }

        public Organization GetOrganization()
        {
            return _context.Organizations.FirstOrDefault();
        }

        public string updateorganization(Organization organization)
        {
           _context.Organizations.Update(organization);
            _context.SaveChanges();
            return "Organization updated successfully";
        }
    }
}

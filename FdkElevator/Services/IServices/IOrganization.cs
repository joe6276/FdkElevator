using FdkElevator.Models.Organization;

namespace FdkElevator.Services.IServices
{
    public interface IOrganization
    {
        string addOrganization(Organization org);
        Organization GetOrganization();

        string updateorganization(Organization organization);


    }
}

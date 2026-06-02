using FdkElevator.AppDbContext;
using FdkElevator.DTOS.TenantDTOS;
using FdkElevator.Models.Tenants;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class ContractService : IContract
    {

        private readonly ApplicationDbContext _context;

        public ContractService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string addContract(MyContract contract)
        {
           _context.Add(contract);
            _context.SaveChanges();
            return "Contract added successfully";
        }

        public string deleteContract(MyContract contract)
        {
            _context.Contracts.Remove(contract);
            _context.SaveChanges();
            return "Contract deleted successfully";
        }

        public MyContract getContract(Guid contractId)
        {
           return _context.Contracts.FirstOrDefault(c => c.Id == contractId)!;
        }

        public List<MyContract> getContractsByTenantId(Guid tenantId)
        {
            return _context.Contracts.Where(c => c.TenantId == tenantId).ToList();
        }

        public bool signContract(SignContractDTO signContractDTO)
        {
           var projectTeam = _context.projectTeams.FirstOrDefault(pt => pt.ProjectId == signContractDTO.ProjectId && pt.UserId == signContractDTO.UserId);

            if(projectTeam == null)
            {
                return false; // User is not part of the project team
            }

            projectTeam.IsContractSigned = true;
            projectTeam.ContractLink = signContractDTO.ContractLink;
            _context.projectTeams.Update(projectTeam);
            _context.SaveChanges();

            return true; 
        }

        public string updateContract(MyContract contract)
        {
          _context.Contracts.Update(contract);
            _context.SaveChanges();
            return "Contract updated successfully";
        }
    }
}

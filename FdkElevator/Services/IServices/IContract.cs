using FdkElevator.DTOS.TenantDTOS;
using FdkElevator.Models.Tenants;

namespace FdkElevator.Services.IServices
{
    public interface  IContract
    {

        string addContract(MyContract contract);

        List<MyContract> getContractsByTenantId(Guid tenantId);

        MyContract getContract(Guid contractId);
        string updateContract(MyContract contract);

        string deleteContract(MyContract contract);

        bool signContract(SignContractDTO signContractDTO);
    }
}

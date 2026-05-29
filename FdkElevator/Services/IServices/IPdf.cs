using FdkElevator.DTOS.PDFDTO;
using FdkElevator.DTOS.TenantDTOS;

namespace FdkElevator.Services.IServices
{
    public interface IPdf
    {

        byte[] GeneratePdf(QuotationRequest q, TenantInformation tenant);
    }
}

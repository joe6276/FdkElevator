using AutoMapper;
using FdkElevator.AppDbContext;
using FdkElevator.DTOS.CommissionDTO;
using FdkElevator.Migrations;
using FdkElevator.Models.Commissions;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class CommissionService : ICommission
    {   

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CommissionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public string addCommissioning(Commission commission)
        {
         _context.Commissions.Add(commission);
            _context.SaveChanges();
            return "Commissioning added successfully";
        }

        public async Task<CommissionResponse> getCommissionsById(Guid commissionId)
        {
            var commission = await _context.Commissions
                .Include(c => c.project)
                .Include(c => c.user)
                .Include(c => c.safetyCheck)
                .Include(c => c.functionalTest)
                .Include(c => c.punchList).ThenInclude(pl => pl.Punches)
                .Include(c => c.clientTraining)
                .Include(c => c.generatedDocumentsCertificate)
                    .ThenInclude(g => g.Certificates)
                        .ThenInclude(cert => cert.user)
                .FirstOrDefaultAsync(c => c.Id == commissionId)
                    ?? throw new KeyNotFoundException($"No commission found with Id {commissionId}.");

            return _mapper.Map<CommissionResponse>(commission);
        }

     

        public async Task<CommissionResponse> getCommissionsByProjectId(Guid projectId)
        {
            var commission = await _context.Commissions
             .Include(c => c.project)
             .Include(c => c.user)
             .Include(c => c.safetyCheck)
             .Include(c => c.functionalTest)
             .Include(c => c.punchList)
                 .ThenInclude(pl => pl.Punches)
             .Include(c => c.clientTraining)
             .Include(c => c.generatedDocumentsCertificate)
                 .ThenInclude(g => g.Certificates)
                     .ThenInclude(cert => cert.user)
             .FirstOrDefaultAsync(c => c.ProjectId == projectId)
                ?? throw new KeyNotFoundException($"No commission found for project {projectId}.");

            return _mapper.Map<CommissionResponse>(commission);
        }
    }
}

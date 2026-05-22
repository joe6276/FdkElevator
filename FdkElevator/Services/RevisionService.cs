using FdkElevator.AppDbContext;
using FdkElevator.DTOS.QuotationDTOS;
using FdkElevator.Models.Quotations;
using FdkElevator.Services.IServices;

namespace FdkElevator.Services
{
    public class RevisionService : IRevision
    {

        private readonly ApplicationDbContext _context;

        public RevisionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string GenerateTrackingNumber()
        {
            return $"RVS-{Guid.NewGuid().ToString("N")[..8].ToUpper()}";
        }

        public string addRevision(Revision revision)
        {
            try
            {
                _context.revisions.Add(revision);
                revision.RevisionNumber = GenerateTrackingNumber();
                _context.SaveChanges();
                return "Revision added successfully";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<RevisionResponseDTO> getAllRevisions(Guid tenantId)
        {
            var leadIds = _context.Leads.Where(l => l.TenantId == tenantId).Select(l => l.Id).ToList();

            return _context.revisions.Where(q => leadIds.Contains(q.LeadId)).Select(q => new RevisionResponseDTO
            {
                SubTotal = q.SubTotal,
                Amount = q.Amount,
                ClientId = q.ClientId,
                Discount = q.Discount,
                LeadId = q.LeadId,
                Status = q.Status,
                InstallationCost = q.InstallationCost,
                FreightCost = q.FreightCost,
                CustomsCost = q.CustomsCost,
                SubcontractorCost = q.SubcontractorCost,
                Warranty = q.Warranty,
                AmcOption = q.AmcOption,
                PaymentTerms = new QuotationPaymentResponseDTO
                {
                    Id = q.Payment.FirstOrDefault().Id,
                    Amount = q.Payment.FirstOrDefault().Amount,
                    Status = q.Payment.FirstOrDefault().Status,
                },
                ValidityDays = q.ValidityDays,
                QuotationNumber = q.RevisionNumber,
                config = new AddLiftConfiguration
                {
                    LiftType = q.configuration.LiftType,
                    DriveType = q.configuration.DriveType,
                    Capacity = q.configuration.Capacity,
                    Speed = q.configuration.Speed,
                    Stops = q.configuration.Stops,
                    DoorType = q.configuration.DoorType,
                    ControllerType = q.configuration.ControllerType,
                    CabinFinish = q.configuration.CabinFinish,
                },
                Items = q.Items.Select(i => new QuotationItemDTO
                {
                    ItemName = i.ItemName,
                    Description = i.Description,
                    ImageURL = i.ImageURL,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            }).ToList();
        }

        public List<RevisionResponseDTO> getRevisionByClientId(Guid id)
        {
            return _context.revisions.Where(q => q.ClientId == id).Select(q => new RevisionResponseDTO
            {
                SubTotal = q.SubTotal,
                Amount = q.Amount,
                ClientId = q.ClientId,
                Discount = q.Discount,
                LeadId = q.LeadId,
                Status = q.Status,
                InstallationCost = q.InstallationCost,
                FreightCost = q.FreightCost,
                CustomsCost = q.CustomsCost,
                SubcontractorCost = q.SubcontractorCost,
                Warranty = q.Warranty,
                AmcOption = q.AmcOption,
                PaymentTerms = new QuotationPaymentResponseDTO
                {
                    Id = q.Payment.FirstOrDefault().Id,
                    Amount = q.Payment.FirstOrDefault().Amount,
                    Status = q.Payment.FirstOrDefault().Status,
                },
                ValidityDays = q.ValidityDays,
                config = new AddLiftConfiguration
                {
                    LiftType = q.configuration.LiftType,
                    DriveType = q.configuration.DriveType,
                    Capacity = q.configuration.Capacity,
                    Speed = q.configuration.Speed,
                    Stops = q.configuration.Stops,
                    DoorType = q.configuration.DoorType,
                    ControllerType = q.configuration.ControllerType,
                    CabinFinish = q.configuration.CabinFinish,
                },
                Items = q.Items.Select(i => new QuotationItemDTO
                {
                    ItemName = i.ItemName,
                    Description = i.Description,
                    ImageURL = i.ImageURL,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            }).ToList();
        }

        public RevisionResponseDTO getRevisionById(Guid id)
        {

            return _context.revisions.Where(q => q.Id == id).Select(q => new RevisionResponseDTO
            {
                SubTotal = q.SubTotal,
                Amount = q.Amount,
                ClientId = q.ClientId,
                Discount = q.Discount,
                LeadId = q.LeadId,
                Status = q.Status,
                InstallationCost = q.InstallationCost,
                FreightCost = q.FreightCost,
                CustomsCost = q.CustomsCost,
                SubcontractorCost = q.SubcontractorCost,
                Warranty = q.Warranty,
                AmcOption = q.AmcOption,
                PaymentTerms = new QuotationPaymentResponseDTO
                {
                    Id = q.Payment.FirstOrDefault().Id,
                    Amount = q.Payment.FirstOrDefault().Amount,
                    Status = q.Payment.FirstOrDefault().Status,
                },
                ValidityDays = q.ValidityDays,
                config = new AddLiftConfiguration
                {
                    LiftType = q.configuration.LiftType,
                    DriveType = q.configuration.DriveType,
                    Capacity = q.configuration.Capacity,
                    Speed = q.configuration.Speed,
                    Stops = q.configuration.Stops,
                    DoorType = q.configuration.DoorType,
                    ControllerType = q.configuration.ControllerType,
                    CabinFinish = q.configuration.CabinFinish,
                },
                Items = q.Items.Select(i => new QuotationItemDTO
                {
                    ItemName = i.ItemName,
                    Description = i.Description,
                    ImageURL = i.ImageURL,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            }).FirstOrDefault();
        }

        public RevisionResponseDTO getRevisionByLeadId(Guid LeadId)
        {
            return _context.revisions.Where(q => q.LeadId == LeadId).Select(q => new RevisionResponseDTO
            {
                SubTotal = q.SubTotal,
                Amount = q.Amount,
                ClientId = q.ClientId,
                Discount = q.Discount,
                LeadId = q.LeadId,
                Status = q.Status,
                InstallationCost = q.InstallationCost,
                FreightCost = q.FreightCost,
                CustomsCost = q.CustomsCost,
                SubcontractorCost = q.SubcontractorCost,
                Warranty = q.Warranty,
                AmcOption = q.AmcOption,
                PaymentTerms = new QuotationPaymentResponseDTO
                {
                    Id = q.Payment.FirstOrDefault().Id,
                    Amount = q.Payment.FirstOrDefault().Amount,
                    Status = q.Payment.FirstOrDefault().Status,
                },
                ValidityDays = q.ValidityDays,
                config = new AddLiftConfiguration
                {
                    LiftType = q.configuration.LiftType,
                    DriveType = q.configuration.DriveType,
                    Capacity = q.configuration.Capacity,
                    Speed = q.configuration.Speed,
                    Stops = q.configuration.Stops,
                    DoorType = q.configuration.DoorType,
                    ControllerType = q.configuration.ControllerType,
                    CabinFinish = q.configuration.CabinFinish,
                },
                Items = q.Items.Select(i => new QuotationItemDTO
                {
                    ItemName = i.ItemName,
                    Description = i.Description,
                    ImageURL = i.ImageURL,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            }).FirstOrDefault();
        }

 
    }
}

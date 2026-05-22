using FdkElevator.AppDbContext;
using FdkElevator.DTOS.QuotationDTOS;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Quotations;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FdkElevator.Services
{
    public class QuotationService : IQuotation
    {   

        private readonly ApplicationDbContext _context;

        public QuotationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string GenerateTrackingNumber()
        {
            return $"QTT-{Guid.NewGuid().ToString("N")[..8].ToUpper()}";
        }
        public string addQuotation(Quotation quotation)
        {
            quotation.QuotationNumber = GenerateTrackingNumber();
            _context.Quotations.Add(quotation);
            _context.SaveChanges();
            return "Quotation added successfully!";
        }


        public List<QuotationResponseDTO> getAllQuotations(Guid tenantId)
        {   
            var leadIds = _context.Leads.Where(l => l.TenantId == tenantId).Select(l => l.Id).ToList();
           
            return _context.Quotations.Where(q => leadIds.Contains(q.LeadId)).Select(q => new QuotationResponseDTO
            {
                SubTotal = q.SubTotal,
                Amount = q.Amount,
                ClientId = q.ClientId,
                Discount = q.Discount,
                LeadId = q.LeadId,
                Status=q.Status,
                Revision=q.Revision,
                InstallationCost=q.InstallationCost,
                FreightCost= q.FreightCost,
                CustomsCost=q.CustomsCost,
                SubcontractorCost=q.SubcontractorCost,
                Warranty=q.Warranty,
                AmcOption=q.AmcOption,
                PaymentTerms = new QuotationPaymentResponseDTO
                {
                    Id = q.Payment.FirstOrDefault().Id,

                    Amount = q.Payment.FirstOrDefault().Amount,
                    Status = q.Payment.FirstOrDefault().Status,
                },
                ValidityDays =q.ValidityDays,
                QuotationNumber=q.QuotationNumber,
                config= new AddLiftConfiguration
                {
                    LiftType=q.configuration.LiftType,
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

        public List<QuotationResponseDTO> getQuotationByClientId(Guid id)
        {
            return _context.Quotations.Where(q => q.ClientId == id).Select(q => new QuotationResponseDTO
            {
                SubTotal = q.SubTotal,
                Amount = q.Amount,
                ClientId = q.ClientId,
                Discount = q.Discount,
                LeadId = q.LeadId,
                Status = q.Status,
                Revision = q.Revision,
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

        public QuotationResponseDTO getQuotationById(Guid id)
        {
        
            return _context.Quotations.Where(q => q.Id == id).Select(q => new QuotationResponseDTO
            {
                SubTotal = q.SubTotal,
                Amount = q.Amount,
                ClientId = q.ClientId,
                Discount = q.Discount,
                LeadId = q.LeadId,
                Status = q.Status,
                Revision = q.Revision,
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

        public QuotationResponseDTO getQuotationByLeadId(Guid LeadId)
        {
          
            return _context.Quotations.Where(q => q.LeadId == LeadId).Select(q => new QuotationResponseDTO
            {
                SubTotal = q.SubTotal,
                Amount = q.Amount,
                ClientId = q.ClientId,
                Discount = q.Discount,
                LeadId = q.LeadId,
                Status = q.Status,
                Revision = q.Revision,
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

        public string updateQuotation(Guid id, QuotationStatus status)
        {
            var quotation = _context.Quotations.FirstOrDefault(q => q.Id == id);
            if (quotation == null)
            {
                throw new Exception("Quotation not found!");
            }

            quotation.Status = status;
            _context.Quotations.Update(quotation);
            _context.SaveChanges();
            return "Quotation updated successfully!";
        }

        public QuotationRevision GetQuotationById(Guid id)
        {
            var quotation = _context.Quotations.Where(x => x.Id == id).Select(x=> new QuotationRevision
            {
                Id = x.Id,
                LeadId = x.LeadId,
                ClientId = x.ClientId,


            }).FirstOrDefault();
            return quotation;
        }

        public string updateRevisedQuote(Guid Id)
        {
            var quotation = _context.Quotations.Where(x => x.Id == Id).FirstOrDefault();

            if(quotation == null)
            {
                throw new Exception("Quotation Not Found");
            }

            quotation.Status = QuotationStatus.Revised;
            _context.Quotations.Update(quotation);
            _context.SaveChanges();

            return "Quotation Updated Successfully!";
        }
    }
}

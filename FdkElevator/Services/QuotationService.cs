using FdkElevator.AppDbContext;
using FdkElevator.DTOS.PDFDTO;
using FdkElevator.DTOS.QuotationDTOS;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Quotations;
using FdkElevator.Models.Surveyors;
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


    
            public async Task<QuotationRequest?> GetQuotationDocument(Guid quotationId)
            {
               var quotation = await _context.Quotations
        .AsNoTracking()
        .Include(q => q.Lead)
        .Include(q => q.User)
        .Include(q => q.configuration)
        .FirstOrDefaultAsync(q => q.Id == quotationId);

    if (quotation is null) return null;

    // Step 2: Fetch the single survey for this lead in ONE query
    // with all owned/navigation sections included
    var survey = await _context.AllSurveys
        .AsNoTracking()
        .Include(s => s.ProjectInfo)
        .Include(s => s.ShaftStructuralInfo)
        .Include(s => s.EntranceDoorDetails)
        .Include(s => s.PowerElectricalInfo)
        .Include(s => s.UsageTrafficInfo)
        .Include(s => s.FinishingDesignPreferences)
        .Include(s => s.SafetyComplianceInfo)
        .Include(s => s.MaintenanceServiceInfo)
        .Include(s => s.AdditionalNotes)
        .FirstOrDefaultAsync(s => s.LeadId == quotation.LeadId);

    // Step 3: Map to your DTO — clean, explicit, no nulls swallowed silently
    return new QuotationRequest
    {
        QuotationNumber = quotation.QuotationNumber,
        QuotationDate   = quotation.CreatedAt.ToString("dd/MM/yyyy"),
        ProjectName     = quotation.Lead?.CompanyName  ?? string.Empty,
        ClientName      = quotation.User?.Name         ?? string.Empty,
        ValidityDate    = quotation.CreatedAt
                            .AddDays(quotation.ValidityDays)
                            .ToString("dd/MM/yyyy"),

        QuotationCalculations = new QuotationCalculations
        {
            Amount            = (decimal)quotation.Amount,
            Discount          = (decimal)quotation.Discount,
            SubTotal          = (decimal)quotation.SubTotal,
            InstallationCost  = quotation.InstallationCost,
            FreightCost       = quotation.FreightCost,
            CustomsCost       = quotation.CustomsCost,
            SubcontractorCost = quotation.SubcontractorCost
        },

        QuotationLiftConfig = new QuotationLiftConfig
        {
            LiftType       = quotation.configuration?.LiftType       ?? string.Empty,
            DriveType      = quotation.configuration?.DriveType      ?? string.Empty,
            Capacity       = quotation.configuration?.Capacity       ?? string.Empty,
            Speed          = quotation.configuration?.Speed          ?? string.Empty,
            Stops          = quotation.configuration?.Stops          ?? string.Empty,
            DoorType       = quotation.configuration?.DoorType       ?? string.Empty,
            ControllerType = quotation.configuration?.ControllerType ?? string.Empty,
            CabinFinish    = quotation.configuration?.CabinFinish    ?? string.Empty
        },

        QuotationSpec = new QuotationSpecification
        {
            ProjectInfo = new ProjectInfo
            {
                NumberOfLiftsRequired       = survey?.ProjectInfo?.NumberOfLiftsRequired ?? 0,
                ExpectedCapacity            = survey?.ProjectInfo?.ExpectedCapacity            ?? string.Empty,
                NumberOfStopsFloors         = survey?.ProjectInfo?.NumberOfStopsFloors         ?? 0,
                TravelHeightMeters          = survey?.ProjectInfo?.TravelHeightMeters          ?? 0,
                EstimatedCompletionTimeline = survey?.ProjectInfo?.EstimatedCompletionTimeline ?? string.Empty
            },

            ShaftStructuralInfo = new ShaftStructuralInfo
            {
                ShaftSize              = survey?.ShaftStructuralInfo?.ShaftSize              ?? string.Empty,
                ShaftHeight            = survey?.ShaftStructuralInfo?.ShaftHeight            ?? 0,
                PitDepth               = survey?.ShaftStructuralInfo?.PitDepth               ?? 0,
                OverheadHeightHeadroom = survey?.ShaftStructuralInfo?.OverheadHeightHeadroom ?? 0,
                CoreCuttingRequired    = survey?.ShaftStructuralInfo?.CoreCuttingRequired    ?? false,
                MachineRoomAvailability= survey?.ShaftStructuralInfo?.MachineRoomAvailability?? false,
                CivilWorksRequired     = survey?.ShaftStructuralInfo?.CivilWorksRequired     ?? false
            },

            EntranceDoorDetails = new EntranceDoorDetails
            {
                NumberOfEntrances           = survey?.EntranceDoorDetails?.NumberOfEntrances           ?? 0,
                DoorSize                    = survey?.EntranceDoorDetails?.DoorSize                    ?? string.Empty,
                LandingDoorFinishPreference = survey?.EntranceDoorDetails?.LandingDoorFinishPreference ?? string.Empty
            },

            PowerElectricalInfo = new PowerElectricalInfo
            {
                VoltageAvailable                = survey?.PowerElectricalInfo?.VoltageAvailable                ?? string.Empty,
                BackupGeneratorAvailable        = survey?.PowerElectricalInfo?.BackupGeneratorAvailable        ?? false,
                DedicatedLiftPowerLineAvailable = survey?.PowerElectricalInfo?.DedicatedLiftPowerLineAvailable ?? false
            },

            UsageTrafficInfo = new UsageTrafficInfo
            {
                EstimatedDailyTraffic = survey?.UsageTrafficInfo?.EstimatedDailyTraffic ?? string.Empty,
                PeakUsageHours        = survey?.UsageTrafficInfo?.PeakUsageHours        ?? string.Empty
            },

            FinishingDesignPreferences = new FinishingDesignPrefs
            {
                CabinFinishPreference = survey?.FinishingDesignPreferences?.CabinFinishPreference ?? string.Empty,
                FlooringPreference    = survey?.FinishingDesignPreferences?.FlooringPreference    ?? string.Empty,
                CeilingType           = survey?.FinishingDesignPreferences?.CeilingType           ?? string.Empty,
                MirrorRequired        = survey?.FinishingDesignPreferences?.MirrorRequired        ?? false,
                HandrailsRequired     = survey?.FinishingDesignPreferences?.HandrailsRequired     ?? false,
                DisplayTypePreference = survey?.FinishingDesignPreferences?.DisplayTypePreference ?? string.Empty
            },

            SafetyComplianceInfo = new SafetyComplianceInfo
            {
                FiremanOperationRequired      = survey?.SafetyComplianceInfo?.FiremanOperationRequired      ?? false,
                EmergencyRescueSystemRequired = survey?.SafetyComplianceInfo?.EmergencyRescueSystemRequired ?? false,
                CctvRequired                  = survey?.SafetyComplianceInfo?.CctvRequired                  ?? false,
                AccessControlRequired         = survey?.SafetyComplianceInfo?.AccessControlRequired         ?? false,
                ComplianceStandardRequired    = survey?.SafetyComplianceInfo?.ComplianceStandardRequired    ?? string.Empty
            },

            MaintenanceServiceInfo = new MaintenanceServiceInfo
            {
                MaintenanceContractRequired = survey?.MaintenanceServiceInfo?.MaintenanceContractRequired ?? false,
                ExistingLiftOnSite          = survey?.MaintenanceServiceInfo?.ExistingLiftOnSite          ?? false,
                CurrentLiftCondition        = survey?.MaintenanceServiceInfo?.CurrentLiftCondition        ?? string.Empty,
                ServiceFrequencyPreference  = survey?.MaintenanceServiceInfo?.ServiceFrequencyPreference  ?? string.Empty
            },

            AdditionalNotes = new AdditionalNotes
            {
                SpecialRequirements = survey?.AdditionalNotes?.SpecialRequirements ?? string.Empty,
                SiteChallenges      = survey?.AdditionalNotes?.SiteChallenges      ?? string.Empty,
                CustomerComments    = survey?.AdditionalNotes?.CustomerComments    ?? string.Empty,
                SurveyorRemarks     = survey?.AdditionalNotes?.SurveyorRemarks     ?? string.Empty
            }
        }
    };
            }
        
        public List<QuotationResponseDTO> getAllQuotations(Guid tenantId)
        {   
            var leadIds = _context.Leads.Where(l => l.TenantId == tenantId).Select(l => l.Id).ToList();

            return _context.Quotations
       .Where(q => leadIds.Contains(q.LeadId))
       .Select(q => new QuotationResponseDTO
       {
           Id = q.Id,
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
           ValidityDays = q.ValidityDays,
           QuotationNumber = q.QuotationNumber,

           PaymentTerms = q.Payment.Any()
               ? new QuotationPaymentResponseDTO
               {
                   Id = q.Payment.FirstOrDefault().Id,
                   Amount = q.Payment.FirstOrDefault().Amount,
                   Status = q.Payment.FirstOrDefault().Status,
               }
               : null,

           config = q.configuration != null
               ? new AddLiftConfiguration
               {
                   LiftType = q.configuration.LiftType,
                   DriveType = q.configuration.DriveType,
                   Capacity = q.configuration.Capacity,
                   Speed = q.configuration.Speed,
                   Stops = q.configuration.Stops,
                   DoorType = q.configuration.DoorType,
                   ControllerType = q.configuration.ControllerType,
                   CabinFinish = q.configuration.CabinFinish,
               }
               : null,

           Items = q.Items != null
               ? q.Items.Select(i => new QuotationItemDTO
               {
                   ItemName = i.ItemName,
                   Description = i.Description,
                   ImageURL = i.ImageURL,
                   Price = i.Price,
                   Quantity = i.Quantity
               }).ToList()
               : new List<QuotationItemDTO>()
       })
       .ToList();

        }

        public List<QuotationResponseDTO> getQuotationByClientId(Guid id)
        {
            return _context.Quotations
             .Where(q => q.ClientId == id)
             .Select(q => new QuotationResponseDTO
             {
                 Id = q.Id,
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
                 ValidityDays = q.ValidityDays,

                 PaymentTerms = q.Payment
                     .Select(p => new QuotationPaymentResponseDTO
                     {
                         Id = p.Id,
                         Amount = p.Amount,
                         Status = p.Status
                     })
                     .FirstOrDefault(),

                 config = q.configuration != null
                     ? new AddLiftConfiguration
                     {
                         LiftType = q.configuration.LiftType,
                         DriveType = q.configuration.DriveType,
                         Capacity = q.configuration.Capacity,
                         Speed = q.configuration.Speed,
                         Stops = q.configuration.Stops,
                         DoorType = q.configuration.DoorType,
                         ControllerType = q.configuration.ControllerType,
                         CabinFinish = q.configuration.CabinFinish,
                     }
                     : null,

                 Items = q.Items
                     .Select(i => new QuotationItemDTO
                     {
                         ItemName = i.ItemName,
                         Description = i.Description,
                         ImageURL = i.ImageURL,
                         Price = i.Price,
                         Quantity = i.Quantity
                     })
                     .ToList()
             })
             .ToList();
        }

        public QuotationResponseDTO getQuotationById(Guid id)
        {

            return _context.Quotations
          .Where(q => q.Id == id)
          .Select(q => new QuotationResponseDTO
          {
              Id = q.Id,
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
              ValidityDays = q.ValidityDays,

              PaymentTerms = q.Payment
                  .Select(p => new QuotationPaymentResponseDTO
                  {
                      Id = p.Id,
                      Amount = p.Amount,
                      Status = p.Status
                  })
                  .FirstOrDefault(),

              config = q.configuration != null
                  ? new AddLiftConfiguration
                  {
                      LiftType = q.configuration.LiftType,
                      DriveType = q.configuration.DriveType,
                      Capacity = q.configuration.Capacity,
                      Speed = q.configuration.Speed,
                      Stops = q.configuration.Stops,
                      DoorType = q.configuration.DoorType,
                      ControllerType = q.configuration.ControllerType,
                      CabinFinish = q.configuration.CabinFinish,
                  }
                  : null,

              Items = q.Items
                  .Select(i => new QuotationItemDTO
                  {
                      ItemName = i.ItemName,
                      Description = i.Description,
                      ImageURL = i.ImageURL,
                      Price = i.Price,
                      Quantity = i.Quantity
                  })
                  .ToList()
          })
          .FirstOrDefault();
        }

        public QuotationResponseDTO getQuotationByLeadId(Guid LeadId)
        {
            try
            {
                var leadquote = _context.Quotations
                    .Where(q => q.LeadId == LeadId)
                    .Select(q => new QuotationResponseDTO
                    {
                        Id = q.Id,
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
                        ValidityDays = q.ValidityDays,

                        PaymentTerms = q.Payment
                            .Select(p => new QuotationPaymentResponseDTO
                            {
                                Id = p.Id,
                                Amount = p.Amount,
                                Status = p.Status
                            })
                            .FirstOrDefault(),

                        config = q.configuration != null
                            ? new AddLiftConfiguration
                            {
                                LiftType = q.configuration.LiftType,
                                DriveType = q.configuration.DriveType,
                                Capacity = q.configuration.Capacity,
                                Speed = q.configuration.Speed,
                                Stops = q.configuration.Stops,
                                DoorType = q.configuration.DoorType,
                                ControllerType = q.configuration.ControllerType,
                                CabinFinish = q.configuration.CabinFinish,
                            }
                            : null,

                        Items = q.Items
                            .Select(i => new QuotationItemDTO
                            {
                                ItemName = i.ItemName,
                                Description = i.Description,
                                ImageURL = i.ImageURL,
                                Price = i.Price,
                                Quantity = i.Quantity
                            })
                            .ToList()
                    })
                    .FirstOrDefault();

                return leadquote;
            }
            catch (Exception ex)
            {
                throw;
            }
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

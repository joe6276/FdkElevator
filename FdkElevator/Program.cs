using FdkElevator.AppDbContext;
using FdkElevator.DTOS.Auth;
using FdkElevator.DTOS.CivilDTO;
using FdkElevator.DTOS.CommissionDTO;
using FdkElevator.DTOS.ComplaintDTOS;
using FdkElevator.DTOS.InstallationsDTO;
using FdkElevator.DTOS.LeadDTOS;
using FdkElevator.DTOS.OrderDTO;
using FdkElevator.DTOS.OrganizationDTOS;
using FdkElevator.DTOS.ProjectDTOS;
using FdkElevator.DTOS.QuotationDTOS;
using FdkElevator.DTOS.SelectionDTO;
using FdkElevator.DTOS.SupplierDTO;
using FdkElevator.DTOS.SurveyDTOS;
using FdkElevator.DTOS.TenantDTOS;
using FdkElevator.DTOS.WarrantyDTO;
using FdkElevator.Extensions;
using FdkElevator.Models.Auth;
using FdkElevator.Models.Civil;
using FdkElevator.Models.Commissions;
using FdkElevator.Models.Complaints;
using FdkElevator.Models.Installations;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Orders;
using FdkElevator.Models.Organization;
using FdkElevator.Models.Projects;
using FdkElevator.Models.Quotations;
using FdkElevator.Models.Selection;
using FdkElevator.Models.Suppliers;
using FdkElevator.Models.Surveyors;
using FdkElevator.Models.Tenants;
using FdkElevator.Models.Warranty;
using FdkElevator.Services;
using FdkElevator.Services.IServices;
using FdkElevator.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using static FdkElevator.DTOS.ProjectDTOS.ProjectMaintenanceDTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Add Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Cors

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
       builder =>
       {
           builder
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
       });

});

builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<Tenant, TenantDTO>().ReverseMap();
    cfg.CreateMap<OrganizationDTO, Organization>();
    cfg.CreateMap<TenantSubDTO, TenantSub>();
    cfg.CreateMap<UserDTO, User>();
    cfg.CreateMap<ResponseUserDTO, User>().ReverseMap();
    cfg.CreateMap<LeadDTO, Lead>();
    cfg.CreateMap<SurveyDTO, AllSurvey>();
    cfg.CreateMap<QuotationDTO, Quotation>();
    cfg.CreateMap<QuotationItemDTO, QuoteItem>();
    cfg.CreateMap<AssignSurveyDTO, AllSurvey>();
    cfg.CreateMap<AddActivityDTO, Activity>();
    cfg.CreateMap<AddLiftConfiguration, LiftConfiguration>();
    cfg.CreateMap<AddLiftConfiguration, LiftConfigurationRevision>();
    cfg.CreateMap<RevisionDTO, Revision>();
    cfg.CreateMap<QuotationItemDTO, QuoteItemRevision>();
    cfg.CreateMap<AddProjectDTO, Project>();
    cfg.CreateMap<AddTaskDTO, ProjectTask>();
    cfg.CreateMap<AddProjectTeamDTO, ProjectTeam>();
    cfg.CreateMap<AddSupplierDTO, Supplier>();
    cfg.CreateMap<AddSupplierItemDTO, SupplierItem>();

    cfg.CreateMap<ProjectInfoRequest, ProjectInfo>();
    cfg.CreateMap<ShaftStructuralRequest, ShaftStructural>();
    cfg.CreateMap<EntranceDoorRequest, EntranceDoor>();
    cfg.CreateMap<PowerElectricalRequest, PowerElectrical>();
    cfg.CreateMap<UsageTrafficRequest, UsageTraffic>();
    cfg.CreateMap<FinishingDesignRequest, FinishingDesign>();
    cfg.CreateMap<SafetyComplianceRequest, SafetyCompliance>();
    cfg.CreateMap<MaintenanceServiceRequest, MaintenanceService>();
    cfg.CreateMap<SiteMediaAttachmentRequest, SiteMediaAttachment>();
    cfg.CreateMap<AdditionalNoteRequest, AdditionalNote>();
    cfg.CreateMap <SelectedProductDTO,SelectedProduct>();
    cfg.CreateMap<ProductDTO, Product>();
    cfg.CreateMap<CreateOrderDTO, Order>();
    cfg.CreateMap<CreateOrderItemDTO, OrderItem>();
    cfg.CreateMap<CreateShippingAddressDTO, ShippingAddress>();
    cfg.CreateMap<CivilReadinessDTO, CivilReadiness>();
    cfg.CreateMap<InstallationDTO, Installation>();
    cfg.CreateMap<ContractDTO, MyContract>();
    cfg.CreateMap<ProjectPhaseDTO, ProjectPhase>();
    cfg.CreateMap<AddProjectDocs, ProjectDoc>();
    cfg.CreateMap<ProjectSignedDocDTO, ProjectSignedDoc>();
    cfg.CreateMap<ProjectStageDTO, ProjectStage>();
    cfg.CreateMap<AddWarrantyDTO, HandoverWarranty>();

    cfg.CreateMap<CreateCommissionRequest, Commission>();
    cfg.CreateMap<SafetyCheckRequest, SafetyCheck>();
    cfg.CreateMap<FunctionalTestRequest, FunctionalTest>();
    cfg.CreateMap<PunchListRequest, PunchList>();
    cfg.CreateMap<PunchRequest, Punch>();
    cfg.CreateMap<ClientTrainingRequest, ClientTraining>();
    cfg.CreateMap<GeneratedDocumentsCertificateRequest, GeneratedDocumentsCertificate>();
    cfg.CreateMap<CertificateRequest, Certificate>();


    cfg.CreateMap<Commission, CommissionResponse>();
    cfg.CreateMap<SafetyCheck, SafetyCheckResponse>();
    cfg.CreateMap<FunctionalTest, FunctionalTestResponse>();
    cfg.CreateMap<PunchList,PunchListResponse>();
    cfg.CreateMap<Punch, PunchResponse>();
    cfg.CreateMap<ClientTraining, ClientTrainingResponse>();
    cfg.CreateMap<GeneratedDocumentsCertificate, GeneratedDocumentsCertificateResponse>();
    cfg.CreateMap<Certificate, CertificateResponse>();
    cfg.CreateMap<CreateComplaintDto, BreakdownComplaint>();
    cfg.CreateMap<DispatchTechnicianDto, BreakdownDispatch>();
    cfg.CreateMap<SubmitDiagnosisDto, TechnicianDiagnosis>();
    cfg.CreateMap<SparePartDto, SparePartRequest>();
    cfg.CreateMap<CreateQuotationDto, RepairQuotation>()
        .ForMember(dest => dest.TotalAmount,
                   opt => opt.MapFrom(src => src.LaborCost + src.PartsCost));
    cfg.CreateMap<QuotationLineItemDto, QuotationLineItem>()
        .ForMember(dest => dest.TotalPrice,
                   opt => opt.MapFrom(src => src.Quantity * src.UnitPrice));
    cfg.CreateMap<CloseJobDto, JobClosure>();
    cfg.CreateMap<SubmitRCADto, RootCauseAnalysis>();

    // ── Entity → Summary DTO ──────────────────────────
    cfg.CreateMap<BreakdownComplaint, BreakdownComplaintSummaryDto>()
        .ForMember(dest => dest.ProjectName,
                   opt => opt.MapFrom(src => src.Project != null
                                          ? src.Project.ProjectCode
                                          : string.Empty))
        .ForMember(dest => dest.FaultType,
                   opt => opt.MapFrom(src => src.FaultType.ToString()))
        .ForMember(dest => dest.Source,
                   opt => opt.MapFrom(src => src.Source.ToString()))
        .ForMember(dest => dest.Priority,
                   opt => opt.MapFrom(src => src.Priority.ToString()))
        .ForMember(dest => dest.Status,
                   opt => opt.MapFrom(src => src.Status.ToString()))
        .ForMember(dest => dest.SLAStatus,
                   opt => opt.MapFrom(src => src.SLAStatus.ToString()));

    cfg.CreateMap<BreakdownDispatch, DispatchSummaryDto>()
        .ForMember(dest => dest.TechnicianName,
                   opt => opt.MapFrom(src => src.Technician != null
                                          ? src.Technician.Name
                                          : string.Empty));

    cfg.CreateMap<TechnicianDiagnosis, DiagnosisSummaryDto>()
        .ForMember(dest => dest.SafetyStatus,
                   opt => opt.MapFrom(src => src.SafetyStatus.ToString()))
        .ForMember(dest => dest.MediaUrls,
                   opt => opt.MapFrom(src => src.Media != null
                                          ? src.Media.Select(m => m.MediaURL).ToList()
                                          : new List<string>()))
        .ForMember(dest => dest.SpareParts,
                   opt => opt.MapFrom(src => src.SparePartsNeeded != null
                                          ? src.SparePartsNeeded.Select(s => s.PartName).ToList()
                                          : new List<string>()));

    cfg.CreateMap<RepairQuotation, QuotationSummaryDto>()
        .ForMember(dest => dest.Reason,
                   opt => opt.MapFrom(src => src.Reason.ToString()))
        .ForMember(dest => dest.Status,
                   opt => opt.MapFrom(src => src.Status.ToString()));

    cfg.CreateMap<JobClosure, ClosureSummaryDto>()
        .ForMember(dest => dest.LiftRunningStatus,
                   opt => opt.MapFrom(src => src.LiftRunningStatus.ToString()));

    cfg.CreateMap<RootCauseAnalysis, RCASummaryDto>()
        .ForMember(dest => dest.Outcome,
                   opt => opt.MapFrom(src => src.Outcome.ToString()));
    cfg.CreateMap<CreateLiftAssetRequest, LiftAsset>();
    cfg.CreateMap<CreateAssetComponentRequest, AssetComponent>();
    cfg.CreateMap<CreateAMCContractRequest, AMCContract>();
    cfg.CreateMap<UpdateAMCContractRequest, AMCContract>();
    cfg.CreateMap<CreateAMCContractAssetRequest, AMCContractAsset>();
    cfg.CreateMap<CreateWarrantyRecordRequest, WarrantyRecord>();
});

//Services

builder.Services.AddScoped<ITenant, TenantService>();
builder.Services.AddScoped<IOrganization, OrganizationServices>();
builder.Services.AddScoped<IBlob, BlobService>();
builder.Services.AddScoped<ITenantSub, TenantSubService>();
builder.Services.AddScoped<IJwt, JwtService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IEmail, EmailService>();
builder.Services.AddScoped<ILead, LeadService>();
builder.Services.AddScoped<ISurvey, SurveyService>();
builder.Services.AddScoped<IQuotation, QuotationService>();
builder.Services.AddScoped<IClient, ClientService>();
builder.Services.AddScoped<IActivity, ActivityService>();
builder.Services.AddScoped<IRevision, RevisionService>();
builder.Services.AddScoped<IQuotationPayment, QuotationPaymentService>();
builder.Services.AddScoped<IProject, ProjectService>();
builder.Services.AddScoped<ITask, TaskService>();
builder.Services.AddScoped<IProjectTeam, ProjectTeamService>();
builder.Services.AddScoped<ISupplier, SupplierService>();
builder.Services.AddScoped<ISupplierItem, SupplierItemService>();
builder.Services.AddScoped<ISupplierSelection, SupplierSelectionService>();
builder.Services.AddScoped<IOrder, OrderService>();
builder.Services.AddScoped<IPdf, PdfService>();
builder.Services.AddScoped<ICivilReadiness, CivilReadinessServices>();
builder.Services.AddScoped<IInstallation, InstallationService>();
builder.Services.AddScoped<IContract, ContractService>();
builder.Services.AddScoped<IProjectPhase, ProjectPhraseService>();
builder.Services.AddScoped<IProjectDocs, ProjectDocService>();
builder.Services.AddScoped<IProjectSignedDoc, ProjectSignedDocService>();
builder.Services.AddScoped<IProjectStage, ProjectStageService>();
builder.Services.AddScoped<IWarranty, WarrantyService>();
builder.Services.AddScoped<ICommission, CommissionService>();
builder.Services.AddScoped<IProjectMaintenance, ProjectMaintenanceService>();
builder.Services.AddScoped<IBreakdownService, BreakdownService>();
builder.Services.AddScoped<IprojectMaintenanceContract, ProjectMaintenanceContract>();

//custom
Stripe.StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:Key").Get<string>();


builder.AddAppAuthentication();
builder.AddSwaggenGenExtension();
//Stripe
Stripe.StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:Key").Get<string>();

// Configure JWt

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
//Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FDK Elevator ",
        Version = "v1"
    });
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();

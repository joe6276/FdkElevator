using FdkElevator.AppDbContext;
using FdkElevator.DTOS.Auth;
using FdkElevator.DTOS.LeadDTOS;
using FdkElevator.DTOS.OrderDTO;
using FdkElevator.DTOS.OrganizationDTOS;
using FdkElevator.DTOS.ProjectDTOS;
using FdkElevator.DTOS.QuotationDTOS;
using FdkElevator.DTOS.SelectionDTO;
using FdkElevator.DTOS.SupplierDTO;
using FdkElevator.DTOS.SurveyDTOS;
using FdkElevator.DTOS.TenantDTOS;
using FdkElevator.Extensions;
using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Orders;
using FdkElevator.Models.Organization;
using FdkElevator.Models.Projects;
using FdkElevator.Models.Quotations;
using FdkElevator.Models.Selection;
using FdkElevator.Models.Suppliers;
using FdkElevator.Models.Surveyors;
using FdkElevator.Models.Tenants;
using FdkElevator.Services;
using FdkElevator.Services.IServices;
using FdkElevator.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

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

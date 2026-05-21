using FdkElevator.AppDbContext;
using FdkElevator.DTOS.Auth;
using FdkElevator.DTOS.LeadDTOS;
using FdkElevator.DTOS.OrganizationDTOS;
using FdkElevator.DTOS.QuotationDTOS;
using FdkElevator.DTOS.SurveyDTOS;
using FdkElevator.DTOS.TenantDTOS;
using FdkElevator.Extensions;
using FdkElevator.Models.Auth;
using FdkElevator.Models.Leads;
using FdkElevator.Models.Organization;
using FdkElevator.Models.Quotations;
using FdkElevator.Models.Surveyors;
using FdkElevator.Models.Tenants;
using FdkElevator.Services;
using FdkElevator.Services.IServices;
using FdkElevator.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
    cfg.CreateMap<SurveyDTO, Survey>();
    cfg.CreateMap<QuotationDTO, Quotation>();
    cfg.CreateMap<QuotationItemDTO, QuoteItem>();
    cfg.CreateMap<AssignSurveyDTO, Survey>();
    cfg.CreateMap<AddActivityDTO, Activity>();
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

//custom

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

using FdkElevator.AppDbContext;
using FdkElevator.DTOS.OrganizationDTOS;
using FdkElevator.DTOS.TenantDTOS;
using FdkElevator.Models.Organization;
using FdkElevator.Models.Tenant;
using FdkElevator.Services;
using FdkElevator.Services.IServices;
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
});

//Services

builder.Services.AddScoped<ITenant, TenantService>();
builder.Services.AddScoped<IOrganization, OrganizationServices>();
builder.Services.AddScoped<IBlob, BlobService>();
builder.Services.AddScoped<ITenantSub, TenantSubService>();

//Stripe
Stripe.StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:Key").Get<string>();

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

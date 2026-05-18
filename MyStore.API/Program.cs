using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyStore.Domain.Interfaces;
using MyStore.Infrastructure;
using MyStore.Infrastructure.PostgreExtension;
using MyStore.Infrastructure.Repositories;
using MyStore.Service.AuthService.cs;
using MyStore.Service.Customers;
using MyStore.Service.Employees;
using MyStore.Service.Mapper;
using MyStore.Service.Orders;
using MyStore.Service.Products;
using MyStore.Service.Validators.CustomerDtoValidators;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<MyStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddPostgresVectorDb(builder.Configuration);
builder.Services.AddScoped<IVectorSearchRepository, ProductVectorRepository>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// One call registers all validators in the MyStore.Service assembly
builder.Services.AddValidatorsFromAssemblyContaining<CustomerCreateDtoValidator>();

builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
}).AddMvc();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer          = true,
            ValidateAudience        = true,
            ValidateLifetime        = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer             = builder.Configuration["Jwt:Issuer"],
            ValidAudience           = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey        = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly",    policy => policy.RequireRole("Admin"));
    options.AddPolicy("StaffOrAdmin", policy => policy.RequireRole("Admin", "Staff"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<VectorDbContext>();
    await db.Database.MigrateAsync();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

# Refactor de Customers con Service Layer y Repository Pattern

## Objetivo

El objetivo de esta tarea fue refactorizar el CRUD de `Customers` para dejar de usar `MyStoreDbContext` directamente dentro del controller y mover la lógica a una arquitectura por capas.

Antes:

```text
CustomersController -> MyStoreDbContext
```

Después:

```text
CustomersController
   -> ICustomerService / CustomerService
      -> ICustomerRepository / CustomerRepository
         -> MyStoreDbContext
```

---

## 1. Crear una rama limpia para la tarea

Desde la raíz del proyecto:

```powershell
git branch
git checkout -b feature/bruno-customers-service-repository-clean
```

La rama usada fue:

```text
feature/bruno-customers-service-repository-clean
```

---

## 2. Crear el proyecto `MyStore.Service`

Desde la raíz del proyecto:

```powershell
dotnet new classlib -n MyStore.Service
```

Esto creó la carpeta:

```text
MyStore.Service
```

---

## 3. Agregar `MyStore.Service` a la solución

```powershell
dotnet sln MyStoreApp.slnx add .\MyStore.Service\MyStore.Service.csproj
```

Resultado esperado:

```text
Project `MyStore.Service\MyStore.Service.csproj` added to the solution.
```

---

## 4. Agregar referencias entre proyectos

`MyStore.Service` necesita conocer `MyStore.Domain`:

```powershell
dotnet add .\MyStore.Service\MyStore.Service.csproj reference .\MyStore.Domain\MyStore.Domain.csproj
```

`MyStore.API` necesita conocer `MyStore.Service`:

```powershell
dotnet add .\MyStore.API\MyStore.API.csproj reference .\MyStore.Service\MyStore.Service.csproj
```

`MyStore.Infrastructure` ya tenía referencia a `MyStore.Domain`, pero se verificó con:

```powershell
dotnet add .\MyStore.Infrastructure\MyStore.Infrastructure.csproj reference .\MyStore.Domain\MyStore.Domain.csproj
```

Si sale este mensaje, está bien:

```text
Project already has a reference to `..\MyStore.Domain\MyStore.Domain.csproj`.
```

---

## 5. Instalar AutoMapper

Se instalaron versiones compatibles para evitar el error de conflicto entre AutoMapper y su extensión de Dependency Injection.

```powershell
dotnet add .\MyStore.API\MyStore.API.csproj package AutoMapper --version 12.0.1
dotnet add .\MyStore.API\MyStore.API.csproj package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1

dotnet add .\MyStore.Service\MyStore.Service.csproj package AutoMapper --version 12.0.1
dotnet add .\MyStore.Service\MyStore.Service.csproj package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
```

Para verificar:

```powershell
dotnet list .\MyStore.API\MyStore.API.csproj package
dotnet list .\MyStore.Service\MyStore.Service.csproj package
```

Resultado esperado:

```text
AutoMapper                                           12.0.1
AutoMapper.Extensions.Microsoft.DependencyInjection  12.0.1
```

Nota: puede aparecer el warning `NU1903` de vulnerabilidad en AutoMapper 12.0.1, pero para esta tarea se usó esta versión porque es compatible con `AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.1`.

---

## 6. Crear carpetas necesarias

```powershell
mkdir .\MyStore.Service\Customers
mkdir .\MyStore.Service\DTOs
mkdir .\MyStore.Service\Mapper

mkdir .\MyStore.Domain\Interfaces
mkdir .\MyStore.Infrastructure\Repositories
```

---

## 7. Crear archivos necesarios

```powershell
New-Item .\MyStore.Domain\Interfaces\ICustomerRepository.cs
New-Item .\MyStore.Infrastructure\Repositories\CustomerRepository.cs

New-Item .\MyStore.Service\Customers\ICustomerService.cs
New-Item .\MyStore.Service\Customers\CustomerService.cs

New-Item .\MyStore.Service\DTOs\CustomerCreateDto.cs
New-Item .\MyStore.Service\DTOs\CustomerReadDto.cs
New-Item .\MyStore.Service\DTOs\CustomerUpdateDto.cs

New-Item .\MyStore.Service\Mapper\MappingProfile.cs
```

También se eliminó el archivo por defecto del class library:

```powershell
Remove-Item .\MyStore.Service\Class1.cs
```

---

# Código agregado

## 8. `ICustomerRepository.cs`

Ruta:

```text
MyStore.Domain/Interfaces/ICustomerRepository.cs
```

Código:

```csharp
using MyStore.Domain.Model;

namespace MyStore.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        Task SaveChangesAsync();
    }
}
```

---

## 9. `CustomerRepository.cs`

Ruta:

```text
MyStore.Infrastructure/Repositories/CustomerRepository.cs
```

Código:

```csharp
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;

namespace MyStore.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MyStoreDbContext _context;

        public CustomerRepository(MyStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
```

---

## 10. `CustomerCreateDto.cs`

Ruta:

```text
MyStore.Service/DTOs/CustomerCreateDto.cs
```

Código:

```csharp
namespace MyStore.Service.DTOs
{
    public class CustomerCreateDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public bool IsPremium { get; set; }
    }
}
```

---

## 11. `CustomerReadDto.cs`

Ruta:

```text
MyStore.Service/DTOs/CustomerReadDto.cs
```

Código:

```csharp
namespace MyStore.Service.DTOs
{
    public class CustomerReadDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public int PointsBalance { get; set; }

        public bool IsPremium { get; set; }

        public DateTime? LastPurchaseDate { get; set; }
    }
}
```

---

## 12. `CustomerUpdateDto.cs`

Ruta:

```text
MyStore.Service/DTOs/CustomerUpdateDto.cs
```

Código:

```csharp
namespace MyStore.Service.DTOs
{
    public class CustomerUpdateDto
    {
        public string Email { get; set; }

        public string FullName { get; set; }
    }
}
```

---

## 13. `ICustomerService.cs`

Ruta:

```text
MyStore.Service/Customers/ICustomerService.cs
```

Código:

```csharp
using MyStore.Service.DTOs;

namespace MyStore.Service.Customers
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerReadDto>> GetCustomersAsync();

        Task<CustomerReadDto?> GetCustomerByIdAsync(int id);

        Task<CustomerReadDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto);

        Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDto customerUpdateDto);

        Task<bool> DeleteCustomerAsync(int id);
    }
}
```

---

## 14. `CustomerService.cs`

Ruta:

```text
MyStore.Service/Customers/CustomerService.cs
```

Código:

```csharp
using AutoMapper;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using MyStore.Service.DTOs;

namespace MyStore.Service.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerReadDto>> GetCustomersAsync()
        {
            var customers = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<CustomerReadDto>>(customers);
        }

        public async Task<CustomerReadDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer == null)
            {
                return null;
            }

            return _mapper.Map<CustomerReadDto>(customer);
        }

        public async Task<CustomerReadDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto)
        {
            var customer = _mapper.Map<Customer>(customerCreateDto);

            await _repository.AddAsync(customer);
            await _repository.SaveChangesAsync();

            return _mapper.Map<CustomerReadDto>(customer);
        }

        public async Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDto customerUpdateDto)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer == null)
            {
                return false;
            }

            _mapper.Map(customerUpdateDto, customer);

            _repository.Update(customer);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer == null)
            {
                return false;
            }

            _repository.Delete(customer);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
```

---

## 15. `MappingProfile.cs`

Ruta:

```text
MyStore.Service/Mapper/MappingProfile.cs
```

Código:

```csharp
using AutoMapper;
using MyStore.Domain.Model;
using MyStore.Service.DTOs;

namespace MyStore.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();
        }
    }
}
```

---

## 16. Refactor de `CustomersController.cs`

Ruta:

```text
MyStore.API/Controllers/CustomersController.cs
```

Antes, el controller usaba directamente:

```csharp
MyStoreDbContext
_context.Customers.ToListAsync()
_context.Customers.FindAsync(id)
_context.Customers.Add(customer)
_context.Customers.Remove(customer)
_context.SaveChangesAsync()
```

Después, se reemplazó por `ICustomerService`.

Código final:

```csharp
using Microsoft.AspNetCore.Mvc;
using MyStore.Service.Customers;
using MyStore.Service.DTOs;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetCustomers()
        {
            var customers = await _customerService.GetCustomersAsync();

            return Ok(customers);
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerReadDto>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<CustomerReadDto>> CreateCustomer(CustomerCreateDto dto)
        {
            var customer = await _customerService.CreateCustomerAsync(dto);

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // PUT: api/customers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerUpdateDto dto)
        {
            var updated = await _customerService.UpdateCustomerAsync(id, dto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/customers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var deleted = await _customerService.DeleteCustomerAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
```

---

## 17. Modificar `Program.cs`

Ruta:

```text
MyStore.API/Program.cs
```

Se agregaron estos `using`:

```csharp
using MyStore.Domain.Interfaces;
using MyStore.Infrastructure.Repositories;
using MyStore.Service.Customers;
using MyStore.Service.Mapper;
```

Y se registraron las dependencias:

```csharp
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
```

`Program.cs` final:

```csharp
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Interfaces;
using MyStore.Infrastructure;
using MyStore.Infrastructure.Repositories;
using MyStore.Service.Customers;
using MyStore.Service.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddDbContext<MyStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Dependency Injection for Customers
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();

    return forecast;
})
.WithName("GetWeatherForecast");

app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
```

---

## 18. Limpiar DTOs viejos de Customers en `MyStore.API`

Como Customers ahora usa los DTOs desde `MyStore.Service.DTOs`, se eliminaron solo los DTOs viejos de Customers dentro de `MyStore.API`.

```powershell
Remove-Item .\MyStore.API\DTOs\CustomerCreateDto.cs
Remove-Item .\MyStore.API\DTOs\CustomerReadDto.cs
Remove-Item .\MyStore.API\DTOs\CustomerUpdateDto.cs
```

No se eliminaron los DTOs de:

```text
Product
Order
Employee
```

Porque esos controllers todavía usan `MyStore.API.DTOs`.

---

## 19. Verificaciones realizadas

### Verificar que `CustomersController` ya no use `DbContext`

```powershell
Select-String -Path .\MyStore.API\Controllers\CustomersController.cs -Pattern "MyStoreDbContext|_context|EntityFrameworkCore"
```

Resultado esperado:

```text
No debe devolver nada.
```

Esto confirma que `CustomersController` ya no usa base de datos directamente.

---

### Verificar uso de `MyStore.API.DTOs`

```powershell
Select-String -Path .\MyStore.API\**\*.cs -Pattern "MyStore.API.DTOs"
```

Después de limpiar Customers, está bien si aparecen:

```text
EmployeeController.cs
OrdersController.cs
ProductsController.cs
Order DTOs
Product DTOs
Employee DTOs
```

Pero ya no debe aparecer:

```text
CustomersController.cs
CustomerCreateDto.cs
CustomerReadDto.cs
CustomerUpdateDto.cs
```

---

## 20. Compilar el proyecto

```powershell
dotnet build
```

Resultado esperado:

```text
Build succeeded
```

Pueden aparecer warnings, pero no deben aparecer errores.

---

## 21. Ejecutar la API

```powershell
dotnet run --project .\MyStore.API\MyStore.API.csproj
```

Resultado esperado:

```text
Now listening on: http://localhost:5155
```

---

# Pruebas de API

## GET all customers

```http
GET http://localhost:5155/api/customers
```

---

## POST create customer

```http
POST http://localhost:5155/api/customers
Content-Type: application/json
```

Body:

```json
{
  "id": 0,
  "email": "bruno@test.com",
  "fullName": "Bruno Salinas",
  "isPremium": true
}
```

---

## GET customer by id

```http
GET http://localhost:5155/api/customers/1
```

---

## PUT update customer

```http
PUT http://localhost:5155/api/customers/1
Content-Type: application/json
```

Body:

```json
{
  "email": "bruno.updated@test.com",
  "fullName": "Bruno Updated"
}
```

---

## DELETE customer

```http
DELETE http://localhost:5155/api/customers/1
```

Después de borrar, esta prueba debería devolver `404 Not Found`:

```http
GET http://localhost:5155/api/customers/1
```

---

# Resultado final

Al terminar, Customers quedó refactorizado así:

```text
CustomersController
   -> ICustomerService
      -> CustomerService
         -> ICustomerRepository
            -> CustomerRepository
               -> MyStoreDbContext
```

## Qué se logró

- `CustomersController` ya no usa `MyStoreDbContext`.
- `CustomersController` solo recibe requests HTTP y responde.
- `CustomerService` maneja la lógica de aplicación.
- `CustomerRepository` maneja el acceso a datos.
- Los DTOs de Customers viven en `MyStore.Service/DTOs`.
- AutoMapper se usa para convertir entre `Customer` y los DTOs.
- `Program.cs` registra las dependencias necesarias.
- El proyecto compila correctamente.
- Los endpoints de Customers pueden probarse con GET, POST, PUT y DELETE.

---

# Checklist final

```text
[ ] MyStore.Service creado
[ ] MyStore.Service agregado a la solución
[ ] MyStore.Service referencia a MyStore.Domain
[ ] MyStore.API referencia a MyStore.Service
[ ] AutoMapper instalado en API y Service
[ ] ICustomerRepository creado
[ ] CustomerRepository creado
[ ] ICustomerService creado
[ ] CustomerService creado
[ ] DTOs de Customer creados en MyStore.Service
[ ] MappingProfile creado
[ ] CustomersController usa ICustomerService
[ ] CustomersController ya no usa MyStoreDbContext
[ ] Program.cs registra AutoMapper
[ ] Program.cs registra ICustomerRepository
[ ] Program.cs registra ICustomerService
[ ] DTOs viejos de Customer eliminados de MyStore.API
[ ] dotnet build funciona
[ ] API corre en localhost
[ ] GET customers funciona
[ ] POST customer funciona
[ ] PUT customer funciona
[ ] DELETE customer funciona
```

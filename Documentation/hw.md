
# Implementation and Migrations Summary

## 1. Product Entity Definition
The `Product` class was created with the following fields:
- Id (int)
- Name (string)
- SKU (string)
- Price (decimal)
- Manufacturer (string)
- WarrantyMonths (int)
- Description (string)

## 2. DTO Creation
The following DTOs were implemented:
- `ProductCreateDto`
- `ProductUpdateDto`
- `ProductReadDto` (includes the `DisplayName` field that combines Name and Manufacturer)

## 3. DbContext Configuration
In `MyStoreDbContext` the following was added:
```csharp
public DbSet<Product> Products { get; set; }
```
The precision for the Price field was configured:
```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
	modelBuilder.Entity<Product>()
		.Property(p => p.Price)
		.HasColumnType("decimal(18,2)");
}
```

## 4. ProductsController Implementation
The following endpoints were created:
- GET (all and by id)
- POST
- PUT
- DELETE
The mapping between entity and DTO was done manually, fulfilling the `DisplayName` challenge.

## 5. Migrations and Database Update
Migrations were generated and applied with the following commands:
```bash
dotnet ef migrations add InitialCreate --project MyStore.Infrastructure --startup-project MyStore.API
dotnet ef migrations add UpdateProductPriceType --project MyStore.Infrastructure --startup-project MyStore.API
dotnet ef database update --project MyStore.Infrastructure --startup-project MyStore.API
```
This created and updated the database with the Products table and the correct configuration for the Price field.

# 📦 Inventory Management System

A full-stack inventory system built from scratch using **Clean Architecture** 
and modern .NET technologies.

## 🏗️ Architecture
This project follows **Clean Architecture** principles — dependencies always 
point inward. Business logic is completely isolated from frameworks and databases.

Frontend (Blazor/MAUI)
↓
API Layer
↓
Application Layer  ← business logic lives here
↓
Domain Layer     ← pure C#, zero dependencies
↑
Infrastructure     ← EF Core + SQL Server

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Backend API | ASP.NET Core Web API (.NET 10) |
| Frontend | Blazor WebAssembly + MudBlazor |
| Mobile | .NET MAUI |
| Database | SQL Server + Entity Framework Core 10 |
| Validation | FluentValidation |
| Architecture | Clean Architecture + Repository + Unit of Work |

## 📋 Database Tables
- **Categories** — product categories
- **Suppliers** — product suppliers  
- **Products** — main inventory items (master table)
- **StockMovements** — stock IN/OUT history (detail table)

## 🚀 Getting Started

### Prerequisites
- .NET 10 SDK
- Visual Studio 2022
- SQL Server

### Run the project
1. Clone the repository
2. Update connection string in `InventorySystem.API/appsettings.json`
3. Run migrations:

 Add-Migration InitialCreate -StartupProject InventorySystem.API
Update-Database -StartupProject InventorySystem.API

1. Ve a github.com → New repository

2. Repository name:
   inventory-system-clean-architecture

3. Description:
   Full-stack Inventory Management System built with .NET 10, 
   Clean Architecture, ASP.NET Core Web API, Blazor WebAssembly 
   + MudBlazor, and .NET MAUI mobile app.

4. Visibility: Public ✅ (para el portfolio)

5. ✅ Add a README file

6. .gitignore: VisualStudio

7. Click: Create repository

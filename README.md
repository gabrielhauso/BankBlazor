# BankBlazor

En headless bankapplikation byggd med Blazor WebAssembly och .NET Web API som låter administratörer hantera kunders bankkonton.

## Länk till hemsidan och API: 
Hemsida: https://bankblazor-client-fdabhmd4eqhgf8hv.swedencentral-01.azurewebsites.net

API: https://bankblazor-api-a3hmhna9axe2crgv.swedencentral-01.azurewebsites.net

## Funktioner 
I appen kan du:
- Kolla kundprofiler och deras konton
- Göra insättningar och uttag
- Föra över pengar mellan konton
- Se transaktioner
- Bläddra bland kunder (med paginering)
- Se nästa scottish bank holiday

## Teknisk som används
- Frontend - Blazor WebAssembly (.NET 8)
- Backend - ASP.NET Core Web API (.NET 8)
- Databas - SQL Server + Entity Framework Core (Database First)
- Delat - Class Library (DTOs & ViewModels)
- Hosting - Azure (App Service + SQL Database)

## Struktur
- BankBlazor.API - API med controllers & services
- BankBlazor.Client - frontend (Blazor WASM)
- BankBlazorClassLibrary – delade modeller

## Setup
1. Klona repot
2. Återställ BankBlazor.bak i SQL Server
3. Uppdatera connection string i BankBlazor.API/appsettings.json
4. Sätt rätt API-url i BankBlazor.Client/wwwroot/appsettings.json
5. Starta både API och Client

## API endpoints
- GET /api/Customer - Hämta kunder (med paginering)
- GET /api/Customer/{id} - Hämta en kund
- POST /api/Account/deposit - Sätt in pengar
- POST /api/Account/withdraw - Ta ut pengar
- POST /api/Account/transfer - Överför pengar
- GET /api/Account/{id}/transactions - Transaktioner

## Externt API
Appen hämtar bank holidays från UK Government API för att visa nästa bank holiday.

https://www.gov.uk/bank-holidays.json



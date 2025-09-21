# Employee Collaboration Portal

## Setup Instructions

### 1. Database
- Open SQL Server Management Studio.
- Create a database named `EmployeePortal`.
- Run `database/CreateTables.sql` to create tables.
- Run `database/SeedData.sql` to add sample data (optional).

### 2. Backend (.NET Core)
- Navigate to `EmployeePortalApi` folder.
- Update `appsettings.json` with your SQL Server connection string.
- Run:
  dotnet restore
  dotnet run
- API will be available at http://localhost:5039

### 3. Frontend (Angular)
- Navigate to `employee-portal-ui` folder.
- Run:
  npm install
  ng serve
- Angular app will be available at http://localhost:4200

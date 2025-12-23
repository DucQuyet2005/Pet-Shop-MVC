This project configuration notes:

- Connection strings

  - `appsettings.json`: production/primary connection string (DefaultConnection).
  - `appsettings.Development.json`: development override (DefaultConnection uses LocalDB by default).

- Program.cs

  - Registers `ApplicationDbContext` with SQL Server using `DefaultConnection`.
  - Uses custom Identity `User` entity and configures Identity options (password, lockout, unique email).

- Add EF Core migrations (local development):

  1. Ensure EF tools are available: `dotnet tool install --global dotnet-ef` (if not already installed).
  2. From the project root (where PetShop.csproj is):

```bash
# add a migration (name it e.g. InitialCreate)
dotnet ef migrations add InitialCreate

# apply migrations to the database
dotnet ef database update
```

- Notes
  - If using a separate startup project, add `-s <StartupProject>` and `-p <ProjectWithDbContext>` to `dotnet ef` commands.
  - Keep secrets (production DB credentials) out of source control; use environment variables or User Secrets for development.

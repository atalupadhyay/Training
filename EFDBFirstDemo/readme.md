### Modul 5, Entity Framework Core

#### NuGet Packages:
	- Microsoft.EntityFrameworkCore.SqlServer
	- Microsoft.EntityFrameworkCore.Tools
	- Microsoft.VisualStudio.Web.CodeGeneration.Design

#### Package Manager Console:
Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Racing;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

**Anleitung:**
   - SQL Server Management Studio öffnen und das Script "db-setup.sql" ausführen. Das Script liegt im Folder sql.
   - In Visual Studio die oben angegebenen NuGet Pakete für ASP.NET Core 2.1 im Projekt installieren
   - In der Package Manager Console den oben angegebenen Command zum DbContext scaffolden ausführen
   - Im Models Folder im RacingContext.cs den ConnectionString ausschneiden und in der appsettings.json als DefaultConnection einbauen.
   - In der Startup.cs in der ConfigureServices Methode die Region DBProvider einfügen
   - Im Projekt Root Verzeichnis auf den Controllers Folder Rechte Maus => Add => Controller => Mvc Controller with Views, using Entity Framework
   - Die Anwendung testen.

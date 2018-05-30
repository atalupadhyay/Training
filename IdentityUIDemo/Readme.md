### Modul 8, Security

**Anleitung:**
  1. Rechte Maus auf die Solution Training => Add => New Project => ASP.NET Core Web Application, No Authentication => Name: IdentityUIDemo
  2. Rechte Maus auf das Projekt IdentityUIDemo => Add => New Scaffold Item => Identity => Override all Files => + Data context class "IdentityUIDemoContext" => + User Class "ApplicationUser"
  3. Anpassen der Methode ConfigureServices in der Startup.cs, Hinzufügen der Region DBProviderIdentity
  4. In der Configure Methode die Methode app.UseAuthentication(); aufrufen.
  5. Package Manager Console:
     - add-migration InitialCreate
	 - update-database
  6. Anwendung starten und 2 Benutzer registrieren: 
     - teacher@ppedv.de
	 - student@ppedv.de
  7. Auf dem HomeController auf Klassenebene das Attribut [Authorize] hinzufügen und die Anwendung testen.
  8. Die Anwendung testen.
  9. **Benutzerrollen**: Im Projekt Root Verzeichnis einen Folder Helpers hinzufügen.
  10. Im Helpers Folder die statiche Klasse IdentityHelper mit 2 statischen Konstanten Teacher und Student hinzufügen.
  11. In der Startup.cs die Methode CreateUserRoles hinzufügen, die Methode beinhaltet die Logik der Region CreateUserRoles
  12. die Methode CreateUserRoles am Ende der Configure Methode in der Startup.cs aufrufen: CreateUserRoles(services).Wait();
  13. Im SQL Server Management Studio die Tabellen AspNetUserRoles, AspNetRoles und AspNetUsers abfragen und Daten prüfen
  14. Im HomeController auf den Actions Index, About und Contact die Attribute setzten:
     - [AllowAnonymous]
	 - [Authorize(Roles = IdentityHelper.Teacher)]
	 - [Authorize(Roles = IdentityHelper.Student)]
  15. Die Anwendung testen.
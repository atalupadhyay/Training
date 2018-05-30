### Modul 3, Einführung in MVC, MvcDemo

**Anleitung Teil 1: MVC Entwurfsmuster**
  1. Rechte Maus auf die Solution Training => Add => New Project => Name: MvcDemo => ASP.NET Core Web Application => Web Application (Model-View-Controller)
  2. Verzeichnisstruktur und Dateien im Projekt ansehen
    - Program.cs
	- Startup.cs
	- appsettings.json
	- Properties => launchSettings.json
	- Controllers
	- Models
	- Views
	- wwwroot
	- MvcDemo.csproj
  3. Löschen von:
    - Verzeichnis Controllers, HomeController.cs
	- Verzeichnis Views, Verzeichnis Home
  4. **Temporärer Datenspeicher:**
	- Anpassen der Startup.cs
    - Hinzufügen der region InMemoryDB in der ConfigureServices Methode
	- Anschließend muss für die InMemory Datenbank noch eine DB Kontext Klasse erstellt werden:
	  - Verzeichnis Models => Hinzufügen leere Klasse "MvcDemoContext"
	  - Der MvcDemoContext muss von DbContext ableiten. Anschließend die Region MvcDemoContext hinzufügen. 
  5. **Model Hinzufügen:**
    - Verzeichnis Models => Hinzufügen leere Klasse "Car".
	- Region CarKlasse zur Klasse hinzufügen. Darin befinden sich die Car Members für das Projekt.
  6. **Controller Hinzufügen:**
    - Verzeichnis Controllers => Hinzufügen leere Klasse CarsController
	- CarsController.cs muss von Controller ableiten
	- Region CarsConstructor hinzufügen. Im Konstruktor werden erste Demodaten hinzugefügt.
	- Im CarsController eine Methode **public async Task<IActionResult> Index()** implementieren. 
	  - Die Methode soll eine Liste von Car Objekten selektieren,
	  - und return View() zurück geben.
  7. **View Hinzufügen:**
    - Rechte Maus auf Index() und "Add View..." auswählen
	- Model Klasse: Car, DB Context: MvcDemoContext.cs
  8. *CRUD:*
    - Implementierung von Create, Read, Update, Delete (und Patch) wie in CarsController.cs definiert.
	- **Die Anwendung testen**.

**Anleitung Teil 2: Exception Handling**
  1. Im CarsController in der Index Methode die Region ExceptionDemo einfügen und eine Exception werfen.
  2. Anwendung starten, die Action aufrufen und die DeveloperExceptionPage betrachten. **Die Anwendung testen**.
  3. Rechte Maus auf das Projekt MvcDemo, Properties aufrufen und im Reiter Debug die Environment Variable von Development auf **Production** setzen.
  4. Die Startup.cs im Projekt öffnen und die Configure Methode anpassen:
    - app.UseHsts() auskommentieren
	- Region GeneralExceptions einfügen
  5. Im Verzeichnis Controllers einen neuen Controller: HelperController hinzufügen und die Region Error dort einfügen.
  6. Anwendung starten und testen. Eventuell die Exception im CarsController anpassen.
  7. In der Startup.cs in der Configure Methode im else Zweig die Region StatusCodePage einfügen. **Die Anwendung testen**.
  8. Die Region CustomErrorPageFürStatuscode in der Configure Methode in der Startup.cs einfügen.
  9. Im HelperController die Region ErrorCustom hinzufügen. **Die Anwendung testen**.
  10. Im Projekt Root Verzeichnis einen neuen Folder hinzufügen: Filters
  11. Im Filters Verzeichnis eine neue Klasse hinzufügen: CustomExceptionFilter. Die Klasse muss von ExceptionFilterAttribute ableiten
  12. Den Hook OnException mit der Region ExceptionFilter implementieren
  13. Am Cars Controller über der Index Action den Filter setzen. **Die Anwendung testen**.

**Anleitung Teil 3: Weitere Techniken**
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
  8. **CRUD:**
    - Implementierung von Create, Read, Update, Delete (und Patch) wie in CarsController.cs definiert.
	- **Die Anwendung testen**.

**Anleitung Teil 2: Exception Handling**
  1. Im CarsController in der Index Methode die Region ExceptionDemo einfügen und eine Exception werfen.
  2. Anwendung starten, die Action aufrufen und die DeveloperExceptionPage betrachten. **Die Anwendung testen**.
  3. Rechte Maus auf das Projekt MvcDemo, Properties aufrufen und im Reiter Debug die Environment Variable von Development auf **Production** setzen.
  4. Die Startup.cs im Projekt öffnen und die Configure Methode anpassen:
    - app.UseHsts() auskommentieren
	- Region GeneralExceptions einfügen
  5. Im Verzeichnis Controllers einen neuen Controller: HelperController hinzufügen und die Region Error einfügen.
  6. Eventuell die Exception im CarsController anpassen. **Die Anwendung testen**.
  7. In der Startup.cs in der Configure Methode im else Zweig die Region StatusCodePage einfügen. **Die Anwendung testen**.
  8. Die Region CustomErrorPageFürStatuscode in der Configure Methode in der Startup.cs einfügen.
  9. Im HelperController die Region ErrorCustom hinzufügen. **Die Anwendung testen**.
  10. Im Projekt Root Verzeichnis einen neuen Folder hinzufügen: Filters
  11. Im Filters Verzeichnis eine neue Klasse hinzufügen: CustomExceptionFilter. Die Klasse muss von ExceptionFilterAttribute ableiten
  12. Den Hook OnException mit der Region ExceptionFilter implementieren
  13. Am Cars Controller über der Index Action den Filter setzen. **Die Anwendung testen**.

**Anleitung Teil 3: Conventional Routing**
  1. In der Startup.cs die Methode Configure anpassen und folgende Regions einfügen:
    - Region DefaultRouting. **Die Anwendung testen**.
	- Region ConventionalRouting. **Die Anwendung testen**.
	- Region RouteMiddleware
	- Im Project Root ein Verzeichnis Helpers hinzufügen
	- Die Klasse ApplicationExtensions hinzufügen und die Region RouteMiddleware einfügen
	- Im Helpers Verzeichnis die Klasse MvcDemoRouter hinzufügen und die Region DemoRouter einfügen.
	- **Die Anwendung testen**.

**Anleitung Teil 4: Weitere Techniken**
  1. Im Verzeichnis Controllers, den HelperController anpassen
    - Eine Index Action hinzufügen und die Region TempData einbauen. 
	- Eine View für die Action hinzufügen. Rechte Maus auf Index => Add View... 
	- Im Verzeichnis Views => Index.cshtml wie im Beispiel anpassen.
	- **Die Anwendung testen**.
	- In der Startup.cs in der ConfigureServices Methode, die Region AddSession statt .AddMvc() verwenden und in der Configure Methode app.UseSession(); vor dem Routing aufrufen.
	- **Die Anwendung testen**.
  2. Im HelperController die Methode SetCookies hinzufügen. Die Methode findet sich in der Region Cookies.
  3. Im HelperController die Index Action anpassen und die Region UseCookies einbauen. **Die Anwendung testen**.

**Anleitung Teil 5: TagHelper**
  1. In der View Views => Helper => Index.cshtml HTML Link und HTML Helper hinzufügen. **Die Anwendung testen**.
  2. Im Projekt Root einen neuen Folder hinzufügen: TagHelpers
  3. Im TagHelpers Folder eine Klasse EmailTagHelper hinzufügen, die muss von TagHelper ableiten
  4. In der EmailTagHelper.cs die Region EmailTagHelper einfügen
  5. Im Verzeichnis Views => _ViewImports.cshtml öffnen und **@addTagHelper *, MvcDemo** einfügen.
  6. In der View im Verzeichnis Views => Helper => Index.cshtml den Email Tag Helper verwenden.

**Anleitung Teil 6: ViewComponent**
  1. Im Projekt Root, ein Verzeichnis hinzufügen: ViewComponents
  2. Im Verzeichnis eine Klasse CarsViewComponent.cs hinzufügen und die Region CarsListViewComponent einbauen
  3. Im CarsController das Coding in der Index Action auskommentieren und einfach **return View()** zurückgeben.
  4. In der View Views => Cars => Index.cshtml, das Markup auskommentieren und **@await Component.InvokeAsync("Cars")** aufrufen. **Die Anwendung testen**.



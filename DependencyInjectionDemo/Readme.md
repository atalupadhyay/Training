### Modul 4, Dependency Injection

**Anleitung:**
  1. Rechte Maus auf die Solution Training => Add => New Project => Name: DependencyInjectionDemo => ASP.NET Core Web Application => Web Application (Model-View-Controller)
  2. Anpassen der Startup.cs, hinzufügen der Region DIServices
  3. Im Projekt Root einen Folder hinzufügen: Services
  4. Im Services Folder eine ein Base Interface hinzufügen IGenerate und für Scoped, Singleton und Transient ein erbendes Interface hinzufügen
  5. Die Klasse Generate.cs zum Folder Services hinzufügen und die Interfaces implementieren.
    - IScoped
	- ISingleton
	- ITransient
  6. Die Logik der Generate.cs findet sich in der Region Generate
  7. Im Folder Controllers einen GenerateController hinzufügen und die Region GenerateController implementieren
  8. Eine GenerateController Index View hinzufügen und den ViewBag wie im Beispiel befüllen. **Die Anwendung testen.**
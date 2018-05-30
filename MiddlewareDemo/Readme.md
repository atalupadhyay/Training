### Modul 2, Startup & Middleware

**Anleitung:** 
  1. Rechte Maus auf die Solution Training => Add => New Project => Name: MiddlewareDemo => ASP.NET Core Web Application => Empty 
  2. Hinzufügen Folder Helpers
  3. Hinzufügen Klasse "MiddlewareExtensions"
  4. Hinzufügen der Methoden zur Klasse "MiddlewareExtensions"
     - RunHelloPpedv
	 - UseHelloPpedv
  5. Anpassen der Configure Methode in der Startup.cs und die neue Middleware aufrufen.
  6. Anwendung starten und im Browser betrachten und stoppen.
  7. Hinzufügen der Klasse "HelloPpedvMiddleware" im Helpers Folder
  8. Implementierung der neuen Middleware Klasse
  9. Aufrufen der neuen Middleware im der Startup.cs, Anwendung Starten

  **Run Middleware** schließt den Request ab und kann nicht weiter verkettet werden!

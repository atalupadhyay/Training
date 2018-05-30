### Modul 9, Front-End, APIDemo.WebClient

**Anleitung Teil 1, keine Security:**
  1. Rechte Maus auf die Solution Training => Add => New Project => Name: MvcDemo => ASP.NET Core Web Application => Empty
  2. Im wwwroot eine Index.html und eine app.js hinzufügen
  3. In der app.js wird die API Controller Methode GetAllCars() aufgerufen, das [Authorize] Attribut am API Controller entfernen!!
  4. In der Startup.cs in der Configure Methode app.UseDefaultFiles(); und app.UseStaticFiles(); aufrufen.

**Anleitung Teil 2, Security mit JWT Bearer Tokens:**
  1. Im wwwroot eine Index.html und eine app.js hinzufügen
  2. In der app.js wird die API Controller Methode GetAllCars() aufgerufen, die mittels [Authorize] Attribut geschützt ist.
  3. In der Index.html befindet sich das Login Formular

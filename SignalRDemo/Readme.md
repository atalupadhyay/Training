### Modul 9, Front-End, SignalR

**Anleitung:**
  1. Rechte Maus auf die Solution Training => Add => New Project => ASP.NET Core => Web Application, Individual User Accounts => Name: IdentityUIDemo
  2. Hinzufügen einer package.json Datei, Hinzufügen von "@aspnet/signalr": "^1.0.0-rc1-update1"
  3. npm install im Projekt Root, Kopieren von signalr.js aus dem node_modules Folder nach wwwroot => lib => signalr => signalr.js
  4. Hinzufügen von chat.js im Verzeichnis wwwroot => js, Sourcecode wie im Beispiel
  5. Hinzufüen eines Folders Hubs im Projekt Root.
  6. Hinzufügen einer Klasse ChatHub.cs im Hubs Verzeichnis, Einfügen der Region ChatHub
  7. Im Verzeichnis Pages Add => New Item => Razor Page Name: Chat.cshtml
  8. Das Html Markup wie im Beispiel angegeben einfügen
  9. Die Anwendung starten und 2 Benutzer registrieren
  10. 2 Browserfenster mit unterschiedlichen angemeldeten Benutzern öffnen und Chat in realtime starten.
# PPEDV ASP.NET Core 2.1 Training
ASP.NET Core ist ein Cross-Platform, High-Performance, [Open-Source Framework] (https://github.com/aspnet/home). 
Es eignet sich besonders zur Erstellung von modernen, cloudbasierten, Internetanwendungen.

### Voraussetzung:

  - Visual Studio 2017, Version 15.7.2
  - Visual Studio Code
  - ASP.NET Core 2.1 SDK

In der Solution finden sich Beispiele zu den Modulen 1-10:
  - Setup & Tooling
  - Startup & Middleware
  - Einführung in MVC
  - Dependency Injection
  - Entity Framework Core
  - Schichtenarchitektur
  - REST APIs
  - Security
  - Front-End
  - Hosting & Deployment

### Modul 1, Setup & Tooling
**Ziel:** Das .NET Core 2.1 Framework mittels einer Consolenanwendung kennen lernen.

Die folgenden Anweisungen auf der Console eingeben, um ein erstes .Net Core 2.1 Programm zu erstellen:

  - dotnet
  - dotnet --version
  - dotnet new --help
  - dotnet new console --help
  - md helloppedv
  - cd helloppedv
  - dotnet new console
  - dir
  - type helloppedv.csproj
  - type Program.cs
  - dotnet run

### Modul 2, Startup & Middleware
**Ziel:** Verstehen und Erweitern der Middleware Pipeline einer ASP.NET Core 2.1 Anwendung.

**Beispiele:** 
  - MiddlewareDemo

**Links:** 
[Wie funktioniert die ASP.NET Core 2.1 Middleware Pipeline?](http://blog.ppedv.de/post/2018/05/25/wie-funktioniert-die-asp-net-core-2-1-middleware-pipeline.aspx)

### Modul 3, Einführung in MVC
**Ziel:** Verstehen des MVC Entwurfsmusters in ASP.NET Core 2.1, sowie Kennenlernen der unterschiedlichen Features des MVC Frameworks.

**Beispiele:** 
  - RazorPagesDemo
  - MvcDemo

### Modul 4, Dependency Injection
**Ziel:** Aufrischung von Softwarearchitektur SOLID Prinzipien, IoC, DI und Kennenlernen des .NET Core IoC/DI Frameworks.

**Beispiele:** 
  - DependencyInjectionDemo

### Modul 5, Entity Framework Core
**Ziel:** Einführung in die Persistenz von Daten mittels ORM Entity Framework Core.

**Beispiele:** 
  - EFDBFirstDemo
  - APIDemo

### Modul 6, Schichtenarchitektur
**Ziel:** Verständins für die Architektur moderner Webanwendungen mittels Repository Pattern und UnitOfWork.

**Beispiele:** 
  - APIDemo

### Modul 7, REST APIs
**Ziel:** Aufbau von Wissen im Bezug auf Webservices mittels HTTP Protokoll, sowie Testen und Kennenlernen des ASP.NET Core 2.1 API Frameworks.

**Beispiele:** 
  - APIDemo
  - APIDemo.Tests
  - APIDemo.ClientConsole

### Modul 8, Security
**Ziel:** Aufrischung Theorie Websecurity sowie Verständins für das Absichern von ASP.NET Core 2.1 Anwendungen mittels Identity Framework (Benutzern und Benutzerrollen).

**Beispiele:** 
  - IdentityUIDemo
  - APIDemo

### Modul 9, Front-End
**Ziel:** Theoretischer Überblick über die existierenden Front-End Technologien 2018, sowie Konsomieren der API mittels JavaScript.
Erstellung von Real-Time Webanwendungen mittels ASP.NET Core 2.1 SignalR.

**Beispiele:** 
  - APIDemo.ClientWeb
  - SignalRDemo

### Modul 10, Hosting & Deployment
**Ziel:** Möglichkeiten zum Hosting & Deployment von ASP.NET Core 2.1 Apps aufzeigen.

  - Anleitung Hosting ASP.NET Core 2.1. auf IIS:
    

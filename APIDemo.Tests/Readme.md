### Modul 7, REST APIs, APIDemo.Tests

#### NuGet Packages:
	- FluentAssertions
	- Moq
	- Microsoft.AspNetCore.Mvc.ViewFeatures

**Anleitung:**
  1. Rechte Maus auf die Solution Training => Add => New Project => xUnit Test Project (.NET Core) => Name: APIDemo.Tests
  2. Installation der oben angegebenen NuGet Pakete, sowie hinzufügen der Referenz auf das APIDemo Projekt
  3. Die Test Klasse CarsControllerTests hinzufügen
  4. Die Methode GetAll_ReturnsOkResult_WithCarsRepository() hinzufügen
  5. Die Regions Arrange / Act / Assert implementieren
  6. Run Tests: Menüleiste => Tests => Run => All Tests 
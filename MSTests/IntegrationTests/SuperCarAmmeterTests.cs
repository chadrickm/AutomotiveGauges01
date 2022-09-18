using AutomotiveGauges.Extras;
using FluentAssertions;

namespace MSTests.IntegrationTests;

[TestClass]
public class SuperCarAmmeterTests
{
    [TestMethod]
    public void CarChangesAmpsAndSetsAmmeter()
    {
        // Arrange
        var car = new SuperCar();
        car.Ammeter.CurrentValue.Should().Be(0);

        // Act
        car.ChangeAmperes(100);

        // Assert
        car.Ammeter.CurrentValue.Should().Be(100);
    }
    
    [TestMethod]
    public void CarGoesAboveAmps()
    {
        // Arrange
        var car = new SuperCar();
        car.Ammeter.CurrentValue.Should().Be(0);

        // Act
        car.ChangeAmperes(201);

        // Assert
        car.Ammeter.CurrentValue.Should().Be(200);
        car.CurrentAmperes.Should().Be(201);
    }
}
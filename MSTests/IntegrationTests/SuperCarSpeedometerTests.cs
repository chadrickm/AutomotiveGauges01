using AutomotiveGauges.Extras;
using FluentAssertions;

namespace MSTests.IntegrationTests.SpeedometerTests;

[TestClass]
public class SuperCarSpeedometerTests
{
    [TestMethod]
    public void CarChangesSpeedAndSetsSpeedometer()
    {
        // Arrange
        var car = new SuperCar();
        car.Speedometer.CurrentValue.Should().Be(0);

        // Act
        car.ChangeSpeed(100);

        // Assert
        car.Speedometer.CurrentValue.Should().Be(100);
    }
    
    [TestMethod]
    public void CarGoesAboveSpeedometerSpeed()
    {
        // Arrange
        var car = new SuperCar();
        car.Speedometer.CurrentValue.Should().Be(0);

        // Act
        car.ChangeSpeed(301);

        // Assert
        car.Speedometer.CurrentValue.Should().Be(300);
        car.CurrentSpeed.Should().Be(301);
    }
}
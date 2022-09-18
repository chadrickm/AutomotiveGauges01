using AutomotiveGauges.Extras;
using FluentAssertions;

namespace MSTests.IntegrationTests;

[TestClass]
public class SuperCarTests
{
    [TestMethod]
    public void CarChangesSpeedAndSetsAccelerometer()
    {
        // Arrange
        var car = new SuperCar();
        car.Accelerometer.CurrentValue.Should().Be(0);

        // Act
        car.ChangeSpeed(100);

        // Assert
        car.Accelerometer.CurrentValue.Should().Be(100);
    }

    [TestMethod]
    public void CarChangesSpeedUpAndDownAndKeepsAccelerometer()
    {
        // Arrange
        var car = new SuperCar();
        car.Accelerometer.CurrentValue.Should().Be(0);

        // Act
        car.ChangeSpeed(100);
        car.Accelerometer.CurrentValue.Should().Be(100);
        car.Accelerometer.HighestReachedValue.Should().Be(100);
        car.ChangeSpeed(50);

        // Assert
        car.Accelerometer.CurrentValue.Should().Be(50);
        car.Accelerometer.HighestReachedValue.Should().Be(100);
    }
}
using AutomotiveGauges.Extras;
using FluentAssertions;

namespace MSTests.IntegrationTests;

[TestClass]
public class SuperCarTachometerTests
{
    
    [TestMethod]
    public void ChangingRpmsChangesTachometer()
    {
        // Arrange
        var car = new SuperCar();
        car.Tachometer.CurrentValue.Should().Be(0);

        // Act
        car.ChangeRpms(10000);

        // Assert
        car.Tachometer.CurrentValue.Should().Be(10000);
        car.Tachometer.IsInWarningState.Should().BeFalse();
        car.CurrentRpms.Should().Be(10000);
    }
    
    [TestMethod]
    public void ChangingRpmsToWarningValueSetsWarningTachometer()
    {
        // Arrange
        var car = new SuperCar();
        car.Tachometer.CurrentValue.Should().Be(0);

        // Act
        car.ChangeRpms(70001);

        // Assert
        car.Tachometer.CurrentValue.Should().Be(70001);
        car.Tachometer.IsInWarningState.Should().BeTrue();
        car.CurrentRpms.Should().Be(70001);
    }
}
using AutomotiveGauges;
using AutomotiveGauges.Extras;
using FluentAssertions;

namespace MSTests;

[TestClass]
public class TachometerTests
{
    [TestMethod]
    public void NewTachometerHasAWarningValue()
    {
        // Arrange
        var tachometer = new Tachometer(100000, 90000);

        // Assert
        tachometer.WarningValue.Should().Be(90000);
    }
}

[TestClass]
public class LightControllerTest
{
    [TestMethod]
    public void NewLightControllerShouldStartWithLightOff()
    {
        // Arrange
        var lightController = new DashboardWarningLightController(new Tachometer(100000, 90000));
        
        // Assert
        lightController.IsLightOn.Should().BeFalse();
    }
}
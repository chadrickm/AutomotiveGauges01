using AutomotiveGauges.Extras;
using FluentAssertions;

namespace MSTests.IntegrationTests;

[TestClass]
public class SuperCarOilPressureTests
{
    
    [TestMethod]
    public void OilPressureChanges()
    {
        var car = new SuperCar();
        
        car.ChangeOilPressure(100);

        car.OilPressureGage.CurrentValue.Should().Be(100);
    }
    
    [TestMethod]
    public void OilPressureMaxedOut()
    {
        var car = new SuperCar();
        car.IsEngineInShuttingDownState.Should().BeFalse();
        
        car.ChangeOilPressure(501);

        car.CurrentOilPressure.Should().Be(501);
        car.OilPressureGage.CurrentValue.Should().Be(500);
        car.IsEngineInShuttingDownState.Should().BeTrue();
    }
}
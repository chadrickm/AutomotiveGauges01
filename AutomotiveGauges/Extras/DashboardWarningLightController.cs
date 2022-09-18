using AutomotiveGauges.Common;

namespace AutomotiveGauges.Extras;

public class DashboardWarningLightController : IDisposable // ie subscriber
{
    private readonly Tachometer _tachometer;
    public bool IsLightOn { get; private set; }

    public DashboardWarningLightController(Tachometer tachometer)
    {
        _tachometer = tachometer;
        _tachometer.OnCurrentValueChanged += OnTachometerValueChanged;
    }

    public void OnTachometerValueChanged(object sender, WarnableValueChangedEventArgs args)
    {
        this.IsLightOn = args.IsInWarningState;
    }

    public void Dispose()
    {
        _tachometer.OnCurrentValueChanged -= OnTachometerValueChanged;
    }
}
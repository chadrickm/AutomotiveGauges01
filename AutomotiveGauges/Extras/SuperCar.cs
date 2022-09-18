using AutomotiveGauges.Common;

namespace AutomotiveGauges.Extras;

public class SuperCar : ISpeedChangeable, IAmperesChangeable, IOilPressureChangeable, IRpmChangeable
{
    public int CurrentAmperes { get; private set; }
    public int CurrentOilPressure { get; private set; }
    public int CurrentSpeed { get; private set; }
    public int CurrentRpms { get; private set; }
    public DashboardWarningLightController TachometerWarningLight { get; }
    
    public bool IsEngineInShuttingDownState { get; private set; }

    public SuperCar()
    {
        // If I embraced the dependency
        // this.Accelerometer = new Accelerometer(this, 300);
        // this.Ammeter = new Ammeter(this, 200);
        // this.OilPressureGage = new OilPressureGage(this, 500);
        // this.Speedometer = new Speedometer(this, 300);
        // this.Tachometer = new Tachometer(this, 100000, 70000);
        
        this.Accelerometer = new Accelerometer(300);
        this.Accelerometer.SubscribeToSpeedChanges(this);

        this.Ammeter = new Ammeter(200);
        this.Ammeter.SubscribeToAmperesChanges(this);

        this.OilPressureGage = new OilPressureGage(500);
        this.OilPressureGage.SubscribeToOilPressureChanges(this);

        this.Speedometer = new Speedometer(300);
        this.Speedometer.SubscribeToSpeedChanges(this);

        this.Tachometer = new Tachometer(100000, 70000);
        this.Tachometer.SubscribeToSpeedChanges(this);
        
        TachometerWarningLight = new DashboardWarningLightController(this.Tachometer);
    }

    public Tachometer Tachometer { get; set; }

    public Speedometer Speedometer { get; set; }

    public OilPressureGage OilPressureGage { get; set; }

    public Ammeter Ammeter { get; set; }

    public Accelerometer Accelerometer { get; }

    public event EventHandler<ValueChangedEventArgs>? OnAmperesChanged;
    public void ChangeAmperes(int value)
    {
        this.CurrentAmperes = value;
        OnAmperesChanged?.Invoke(this, new ValueChangedEventArgs(value));
    }

    public event EventHandler<ValueChangedEventArgs>? OnOilPressureChanged;
    public void ChangeOilPressure(int value)
    {
        this.CurrentOilPressure = value;
        try
        {
            OnOilPressureChanged?.Invoke(this, new ValueChangedEventArgs(value));
        }
        catch (CriticalThresholdReachedException)
        {
            IsEngineInShuttingDownState = true;
        }
    }

    public event EventHandler<ValueChangedEventArgs>? OnSpeedChanged;
    public void ChangeSpeed(int value)
    {
        this.CurrentSpeed = value;
        OnSpeedChanged?.Invoke(this, new ValueChangedEventArgs(value));
    }

    public event EventHandler<ValueChangedEventArgs>? OnRpmsChanged;
    public void ChangeRpms(int value)
    {
        this.CurrentRpms = value;
        OnRpmsChanged?.Invoke(this, new ValueChangedEventArgs(value));
    }
}
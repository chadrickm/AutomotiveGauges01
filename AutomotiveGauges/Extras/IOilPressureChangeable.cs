using AutomotiveGauges.Common;

namespace AutomotiveGauges.Extras;

public interface IOilPressureChangeable
{
    int CurrentOilPressure { get; }
    event EventHandler<ValueChangedEventArgs> OnOilPressureChanged;
    void ChangeOilPressure(int value);
}
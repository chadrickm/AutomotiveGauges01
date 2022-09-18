using AutomotiveGauges.Common;

namespace AutomotiveGauges.Extras;

public interface IRpmChangeable
{
    int CurrentRpms { get; }
    event EventHandler<ValueChangedEventArgs> OnRpmsChanged;
    void ChangeRpms(int value);
}
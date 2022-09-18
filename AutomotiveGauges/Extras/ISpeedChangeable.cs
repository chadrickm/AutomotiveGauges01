using AutomotiveGauges.Common;

namespace AutomotiveGauges.Extras;

public interface ISpeedChangeable
{
    int CurrentSpeed { get; }
    event EventHandler<ValueChangedEventArgs> OnSpeedChanged;
    void ChangeSpeed(int value);
}
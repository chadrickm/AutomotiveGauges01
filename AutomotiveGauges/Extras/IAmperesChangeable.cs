using AutomotiveGauges.Common;

namespace AutomotiveGauges.Extras;

public interface IAmperesChangeable
{
    int CurrentAmperes { get; }
    event EventHandler<ValueChangedEventArgs> OnAmperesChanged;
    void ChangeAmperes(int value);
}
namespace AutomotiveGauges.Common;

public class ValueChangedEventArgs : EventArgs
{
    public int NewValue { get; }

    public ValueChangedEventArgs(int newValue)
    {
        NewValue = newValue;
    }
}
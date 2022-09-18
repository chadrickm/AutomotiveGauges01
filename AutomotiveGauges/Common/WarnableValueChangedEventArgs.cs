namespace AutomotiveGauges.Common;

public class WarnableValueChangedEventArgs : EventArgs
{
    public bool IsInWarningState { get; }

    public WarnableValueChangedEventArgs(bool isInWarningState)
    {
        IsInWarningState = isInWarningState;
    }
}
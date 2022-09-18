namespace AutomotiveGauges.Common
{
    public abstract class GageWithWarning : Gage
    {
        public int? WarningValue { get; }
        public bool IsInWarningState => this.CurrentValue >= WarningValue;

        protected GageWithWarning(int maxValue, int warningValue, int minValue = 0) : base(maxValue, minValue)
        {
            WarningValue = warningValue;
        }
        
        public event EventHandler<WarnableValueChangedEventArgs>? OnCurrentValueChanged;

        protected virtual void WarnableValueChanged(WarnableValueChangedEventArgs args)
        {
            OnCurrentValueChanged?.Invoke(this, args);
        }
    }
}
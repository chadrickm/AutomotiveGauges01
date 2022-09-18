namespace AutomotiveGauges.Common
{
    public abstract class Gage
    {
        public int MinValue { get; }
        public int MaxValue { get; }
        public int CurrentValue { get; private set; }

        protected Gage(int maxValue, int minValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        protected virtual void OnValueChanged(object sender, ValueChangedEventArgs args)
        {
            this.CurrentValue = Math.Min(args.NewValue, MaxValue);
        }
    }
}
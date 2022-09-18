using AutomotiveGauges.Common;
using AutomotiveGauges.Extras;

namespace AutomotiveGauges
{
    public interface IHighestValueRecordable
    {
        int HighestReachedValue { get; }
        void SetHighestReachedValueIfHigher(int value);
        void ResetHighestReachedValue();
    }
    
    // 5) Accelerometer, zero to max, with highest level reached stored for later analysis
    public class Accelerometer : Gage, IHighestValueRecordable
    {
        public int HighestReachedValue { get; private set; }

        public Accelerometer(int maxValue) : base(maxValue, 0) { }
        
        // Q: perhaps I should just embrace the dependency because you can't change the value without it.
        // public Accelerometer(ISpeedChangeable vehicle, int maxValue) : base(maxValue, 0)
        // {
        //     vehicle.OnSpeedChanged += OnValueChanged;
        // }
        
        public void SetHighestReachedValueIfHigher(int value)
        {
            HighestReachedValue = Math.Max(HighestReachedValue, value);
        }

        public void ResetHighestReachedValue()
        {
            HighestReachedValue = 0;
        }

        protected override void OnValueChanged(object sender, ValueChangedEventArgs args)
        {
            SetHighestReachedValueIfHigher(args.NewValue);
            base.OnValueChanged(sender, args);
        }

        public void SubscribeToSpeedChanges(ISpeedChangeable publisher)
        {
            publisher.OnSpeedChanged += OnValueChanged;
        }
    }
}
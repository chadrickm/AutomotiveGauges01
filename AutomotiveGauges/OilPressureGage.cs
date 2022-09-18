using AutomotiveGauges.Common;
using AutomotiveGauges.Extras;

namespace AutomotiveGauges
{
    // 3) Oil pressure, min/max that must throw an exception if the maximum value is achieved (warns engine software to shut down)
    // Q: Should this gage have a warning as well so you get warned before your computer goes into shutdown mode?
    public class OilPressureGage : Gage
    {
        public OilPressureGage(int maxValue, int minValue = 0) : base(maxValue, minValue) { }

        protected override void OnValueChanged(object sender, ValueChangedEventArgs args)
        {
            base.OnValueChanged(sender, args);
            if (args.NewValue >= MaxValue) throw new CriticalThresholdReachedException();
        }

        public void SubscribeToOilPressureChanges(IOilPressureChangeable publisher)
        {
            publisher.OnOilPressureChanged += OnValueChanged;
        }
    }
}
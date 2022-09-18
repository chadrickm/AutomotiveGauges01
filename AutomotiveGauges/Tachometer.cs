using AutomotiveGauges.Common;
using AutomotiveGauges.Extras;

namespace AutomotiveGauges
{
    // 2) Tachometer, indicating a minimum and maximum value, as well as a suggested "do not exceed" value ("redline")
    public class Tachometer : GageWithWarning
    {
        public Tachometer(int maxValue, int warningValue, int minValue = 0) : base(maxValue, warningValue, minValue) { }

        protected override void OnValueChanged(object sender, ValueChangedEventArgs args)
        {
            this.WarnableValueChanged(new WarnableValueChangedEventArgs(this.IsInWarningState));
            base.OnValueChanged(sender, args);
        }

        public void SubscribeToSpeedChanges(IRpmChangeable publisher)
        {
            publisher.OnRpmsChanged += OnValueChanged;
        }
    }
}
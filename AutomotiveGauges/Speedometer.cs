using AutomotiveGauges.Common;
using AutomotiveGauges.Extras;

namespace AutomotiveGauges
{
    // 1) Speedometer, indicating a minimum and maximum value
    public class Speedometer : Gage
    {
        public Speedometer(int maxValue, int minValue = 0) : base(maxValue, minValue) { }

        public void SubscribeToSpeedChanges(ISpeedChangeable publisher)
        {
            publisher.OnSpeedChanged += OnValueChanged;
        }
    }
}
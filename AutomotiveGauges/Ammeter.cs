using AutomotiveGauges.Common;
using AutomotiveGauges.Extras;

namespace AutomotiveGauges
{
    // 4) Ammeter, max value only (min value should be assumed to be zero)
    public class Ammeter : Gage
    {
        public Ammeter(int maxValue) : base(maxValue, 0) { }

        public void SubscribeToAmperesChanges(IAmperesChangeable publisher)
        {
            publisher.OnAmperesChanged += OnValueChanged;
        }
    }
}
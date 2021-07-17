using NUnit.Framework;
using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PulseExtension))]
    internal class PulseExtensionSpecification :
        ICondition<Signal>,
        IProduction<Signal>,
        IConsumption<Pulse>,
        ICancellation
    {
        private bool expected;

        private Pulse consumed;

        private IConsumption<Signal> consumption;

        void ICancellation.Cancel()
        {

        }

        ICancellation IProduction<Signal>.Produce(IConsumption<Signal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            this.consumption = consumption;

            return this;
        }

        void IConsumption<Pulse>.Consume(Pulse signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            consumed = signal;
        }

        bool ICondition<Signal>.IsSatisfiedBy(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected;
        }

        private IProduction<Signal> production;

        private ICondition<Signal> condition;

        [SetUp]
        public void SetUp()
        {
            expected = false;

            consumed = null;

            production = this;

            condition = this;
        }

        [Test]
        public void ShouldConvertSignalIntoPulse()
        {
            var cancellation = production.Convert(condition).Produce(this);

            expected = false;
            consumption.Consume(new Signal());
            Assert.AreEqual(consumed, Pulse.IsDisabled);

            expected = true;
            consumption.Consume(new Signal());
            Assert.AreEqual(consumed, Pulse.HasEnabled);

            expected = true;
            consumption.Consume(new Signal());
            Assert.AreEqual(consumed, Pulse.IsEnabled);

            expected = false;
            consumption.Consume(new Signal());
            Assert.AreEqual(consumed, Pulse.HasDisabled);

            cancellation.Cancel();
        }
    }
}

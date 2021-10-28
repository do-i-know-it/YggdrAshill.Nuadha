using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PulseOf))]
    internal class PulseOfSpecification :
        ICondition<Signal>
    {
        private bool expected;

        public bool IsSatisfiedBy(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected;
        }

        [Test]
        public void ShouldConvertSignalIntoPulse()
        {
            // When condition is generated, initial pulse is disabled.
            var conversion = PulseOf.Signal(this);

            // When previous pulse is disabled and condition is not satisfied, current pulse is disabled.
            expected = false;
            Assert.AreEqual(Pulse.IsDisabled, conversion.Translate(new Signal()));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            expected = true;
            Assert.AreEqual(Pulse.HasEnabled, conversion.Translate(new Signal()));

            // When previous pulse has enabled and condition is satisfied, current pulse is enabled.
            expected = true;
            Assert.AreEqual(Pulse.IsEnabled, conversion.Translate(new Signal()));

            // When previous pulse is enabled and condition is not satisfied, current pulse has disabled.
            expected = false;
            Assert.AreEqual(Pulse.HasDisabled, conversion.Translate(new Signal()));

            // When previous pulse has disabled and condition is not satisfied, current pulse is disabled.
            expected = false;
            Assert.AreEqual(Pulse.IsDisabled, conversion.Translate(new Signal()));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            expected = true;
            Assert.AreEqual(Pulse.HasEnabled, conversion.Translate(new Signal()));

            // When previous pulse has enabled and condition is not satisfied, current pulse has disabled.
            expected = false;
            Assert.AreEqual(Pulse.HasDisabled, conversion.Translate(new Signal()));
        }
    }
}
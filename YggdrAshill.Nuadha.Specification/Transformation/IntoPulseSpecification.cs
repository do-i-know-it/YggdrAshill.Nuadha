using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(IntoPulse))]
    internal class IntoPulseSpecification :
        IDetection<Signal>
    {
        private bool expected;

        public bool Detect(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected;
        }

        [Test]
        public void ShouldPulsateAccordingPreviousPulse()
        {
            // initial pulse is disabled when pulsation is generated.
            var pulsation = IntoPulse.From(this);

            // when previous pulse is disabled and detection doesn't detect, current pulse is disabled.
            expected = false;
            Assert.AreEqual(Pulse.IsDisabled, pulsation.Pulsate(new Signal()));

            // when previous pulse is disabled and detection detects, current pulse has enabled.
            expected = true;
            Assert.AreEqual(Pulse.HasEnabled, pulsation.Pulsate(new Signal()));

            // when previous pulse has enabled and detection detects, current pulse is enabled.
            expected = true;
            Assert.AreEqual(Pulse.IsEnabled, pulsation.Pulsate(new Signal()));

            // when previous pulse is enabled and detection doesn't detect, current pulse has disabled.
            expected = false;
            Assert.AreEqual(Pulse.HasDisabled, pulsation.Pulsate(new Signal()));

            // when previous pulse has disabled and detection doesn't detect, current pulse is disabled.
            expected = false;
            Assert.AreEqual(Pulse.IsDisabled, pulsation.Pulsate(new Signal()));

            // when previous pulse is disabled and detection detects, current pulse has enabled.
            expected = true;
            Assert.AreEqual(Pulse.HasEnabled, pulsation.Pulsate(new Signal()));

            // when previous pulse has enabled and detection doesn't detect, current pulse has disabled.
            expected = false;
            Assert.AreEqual(Pulse.HasDisabled, pulsation.Pulsate(new Signal()));
        }
    }
}

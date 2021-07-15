using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PulseIs))]
    internal class PulseIsSpecification
    {
        [Test]
        public void ShouldDetectWhenPulseIsDisabled()
        {
            Assert.IsTrue(PulseIs.Disabled.Detect(Pulse.IsDisabled));
            Assert.IsTrue(PulseIs.Disabled.Detect(Pulse.HasDisabled));
            Assert.IsFalse(PulseIs.Disabled.Detect(Pulse.IsEnabled));
            Assert.IsFalse(PulseIs.Disabled.Detect(Pulse.HasEnabled));
        }

        [Test]
        public void ShouldDetectWhenPulseIsEnabled()
        {
            Assert.IsFalse(PulseIs.Enabled.Detect(Pulse.IsDisabled));
            Assert.IsFalse(PulseIs.Enabled.Detect(Pulse.HasDisabled));
            Assert.IsTrue(PulseIs.Enabled.Detect(Pulse.IsEnabled));
            Assert.IsTrue(PulseIs.Enabled.Detect(Pulse.HasEnabled));
        }
    }
}

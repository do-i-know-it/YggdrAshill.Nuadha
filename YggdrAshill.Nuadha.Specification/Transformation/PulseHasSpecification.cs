using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PulseHas))]
    internal class PulseHasSpecification
    {
        [Test]
        public void ShouldDetectWhenPulseHasDisabled()
        {
            Assert.IsFalse(PulseHas.Disabled.Detect(Pulse.IsDisabled));
            Assert.IsTrue(PulseHas.Disabled.Detect(Pulse.HasDisabled));
            Assert.IsFalse(PulseHas.Disabled.Detect(Pulse.IsEnabled));
            Assert.IsFalse(PulseHas.Disabled.Detect(Pulse.HasEnabled));
        }

        [Test]
        public void ShouldDetectWhenPulseHasEnabled()
        {
            Assert.IsFalse(PulseHas.Enabled.Detect(Pulse.IsDisabled));
            Assert.IsFalse(PulseHas.Enabled.Detect(Pulse.HasDisabled));
            Assert.IsFalse(PulseHas.Enabled.Detect(Pulse.IsEnabled));
            Assert.IsTrue(PulseHas.Enabled.Detect(Pulse.HasEnabled));
        }
    }
}

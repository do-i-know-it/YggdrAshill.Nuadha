using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(WhenPulse))]
    internal class WhenPulseSpecification
    {
        [Test]
        public void ShouldDetectWhenPulseIsDisabled()
        {
            Assert.IsTrue(WhenPulse.IsDisabled.Detect(Pulse.IsDisabled));
            Assert.IsFalse(WhenPulse.IsDisabled.Detect(Pulse.HasDisabled));
            Assert.IsFalse(WhenPulse.IsDisabled.Detect(Pulse.IsEnabled));
            Assert.IsFalse(WhenPulse.IsDisabled.Detect(Pulse.HasEnabled));
        }

        [Test]
        public void ShouldDetectWhenPulseHasDisabled()
        {
            Assert.IsFalse(WhenPulse.HasDisabled.Detect(Pulse.IsDisabled));
            Assert.IsTrue(WhenPulse.HasDisabled.Detect(Pulse.HasDisabled));
            Assert.IsFalse(WhenPulse.HasDisabled.Detect(Pulse.IsEnabled));
            Assert.IsFalse(WhenPulse.HasDisabled.Detect(Pulse.HasEnabled));
        }

        [Test]
        public void ShouldDetectWhenPulseIsEnabled()
        {
            Assert.IsFalse(WhenPulse.IsEnabled.Detect(Pulse.IsDisabled));
            Assert.IsFalse(WhenPulse.IsEnabled.Detect(Pulse.HasDisabled));
            Assert.IsTrue(WhenPulse.IsEnabled.Detect(Pulse.IsEnabled));
            Assert.IsFalse(WhenPulse.IsEnabled.Detect(Pulse.HasEnabled));
        }

        [Test]
        public void ShouldDetectWhenPulseHasEnabled()
        {
            Assert.IsFalse(WhenPulse.HasEnabled.Detect(Pulse.IsDisabled));
            Assert.IsFalse(WhenPulse.HasEnabled.Detect(Pulse.HasDisabled));
            Assert.IsFalse(WhenPulse.HasEnabled.Detect(Pulse.IsEnabled));
            Assert.IsTrue(WhenPulse.HasEnabled.Detect(Pulse.HasEnabled));
        }
    }
}

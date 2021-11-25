using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PulseIs))]
    internal class PulseIsSpecification
    {
        [Test]
        public void ShouldBeSatisfiedWhenPulseIsDisabled()
        {
            Assert.IsTrue(PulseIs.Disabled.Notify(Pulse.IsDisabled));
            Assert.IsTrue(PulseIs.Disabled.Notify(Pulse.HasDisabled));
            Assert.IsFalse(PulseIs.Disabled.Notify(Pulse.IsEnabled));
            Assert.IsFalse(PulseIs.Disabled.Notify(Pulse.HasEnabled));
        }

        [Test]
        public void ShouldBeSatisfiedWhenPulseIsEnabled()
        {
            Assert.IsFalse(PulseIs.Enabled.Notify(Pulse.IsDisabled));
            Assert.IsFalse(PulseIs.Enabled.Notify(Pulse.HasDisabled));
            Assert.IsTrue(PulseIs.Enabled.Notify(Pulse.IsEnabled));
            Assert.IsTrue(PulseIs.Enabled.Notify(Pulse.HasEnabled));
        }
    }
}

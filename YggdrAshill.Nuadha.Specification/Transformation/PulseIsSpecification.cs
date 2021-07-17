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
            Assert.IsTrue(PulseIs.Disabled.IsSatisfiedBy(Pulse.IsDisabled));
            Assert.IsTrue(PulseIs.Disabled.IsSatisfiedBy(Pulse.HasDisabled));
            Assert.IsFalse(PulseIs.Disabled.IsSatisfiedBy(Pulse.IsEnabled));
            Assert.IsFalse(PulseIs.Disabled.IsSatisfiedBy(Pulse.HasEnabled));
        }

        [Test]
        public void ShouldBeSatisfiedWhenPulseIsEnabled()
        {
            Assert.IsFalse(PulseIs.Enabled.IsSatisfiedBy(Pulse.IsDisabled));
            Assert.IsFalse(PulseIs.Enabled.IsSatisfiedBy(Pulse.HasDisabled));
            Assert.IsTrue(PulseIs.Enabled.IsSatisfiedBy(Pulse.IsEnabled));
            Assert.IsTrue(PulseIs.Enabled.IsSatisfiedBy(Pulse.HasEnabled));
        }
    }
}

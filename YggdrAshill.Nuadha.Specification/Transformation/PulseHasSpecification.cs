using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PulseHas))]
    internal class PulseHasSpecification
    {
        [Test]
        public void ShouldBeSatisfiedWhenPulseHasDisabled()
        {
            Assert.IsFalse(PulseHas.Disabled.IsSatisfiedBy(Pulse.IsDisabled));
            Assert.IsTrue(PulseHas.Disabled.IsSatisfiedBy(Pulse.HasDisabled));
            Assert.IsFalse(PulseHas.Disabled.IsSatisfiedBy(Pulse.IsEnabled));
            Assert.IsFalse(PulseHas.Disabled.IsSatisfiedBy(Pulse.HasEnabled));
        }

        [Test]
        public void ShouldBeSatisfiedWhenPulseHasEnabled()
        {
            Assert.IsFalse(PulseHas.Enabled.IsSatisfiedBy(Pulse.IsDisabled));
            Assert.IsFalse(PulseHas.Enabled.IsSatisfiedBy(Pulse.HasDisabled));
            Assert.IsFalse(PulseHas.Enabled.IsSatisfiedBy(Pulse.IsEnabled));
            Assert.IsTrue(PulseHas.Enabled.IsSatisfiedBy(Pulse.HasEnabled));
        }
    }
}

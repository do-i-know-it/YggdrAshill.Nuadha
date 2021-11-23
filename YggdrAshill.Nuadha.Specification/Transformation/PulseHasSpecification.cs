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
            Assert.IsFalse(PulseHas.Disabled.Notify(Pulse.IsDisabled));
            Assert.IsTrue(PulseHas.Disabled.Notify(Pulse.HasDisabled));
            Assert.IsFalse(PulseHas.Disabled.Notify(Pulse.IsEnabled));
            Assert.IsFalse(PulseHas.Disabled.Notify(Pulse.HasEnabled));
        }

        [Test]
        public void ShouldBeSatisfiedWhenPulseHasEnabled()
        {
            Assert.IsFalse(PulseHas.Enabled.Notify(Pulse.IsDisabled));
            Assert.IsFalse(PulseHas.Enabled.Notify(Pulse.HasDisabled));
            Assert.IsFalse(PulseHas.Enabled.Notify(Pulse.IsEnabled));
            Assert.IsTrue(PulseHas.Enabled.Notify(Pulse.HasEnabled));
        }
    }
}

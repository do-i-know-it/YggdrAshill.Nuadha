using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Pulse))]
    internal class PulseSpecification
    {
        [Test]
        public void ShouldBeEqualWhenPulseIsDisabled()
        {
            Assert.IsTrue(Pulse.IsDisabled == Pulse.IsDisabled);
            Assert.IsTrue(Pulse.IsDisabled != Pulse.HasDisabled);
            Assert.IsTrue(Pulse.IsDisabled != Pulse.IsEnabled);
            Assert.IsTrue(Pulse.IsDisabled != Pulse.HasEnabled);
        }

        [Test]
        public void ShouldBeEqualWhenPulseHasDisabled()
        {
            Assert.IsTrue(Pulse.HasDisabled != Pulse.IsDisabled);
            Assert.IsTrue(Pulse.HasDisabled == Pulse.HasDisabled);
            Assert.IsTrue(Pulse.HasDisabled != Pulse.IsEnabled);
            Assert.IsTrue(Pulse.HasDisabled != Pulse.HasEnabled);
        }

        [Test]
        public void ShouldBeEqualWhenPulseIsEnabled()
        {
            Assert.IsTrue(Pulse.IsEnabled != Pulse.IsDisabled);
            Assert.IsTrue(Pulse.IsEnabled != Pulse.HasDisabled);
            Assert.IsTrue(Pulse.IsEnabled == Pulse.IsEnabled);
            Assert.IsTrue(Pulse.IsEnabled != Pulse.HasEnabled);
        }

        [Test]
        public void ShouldBeEqualWhenPulseHasEnabled()
        {
            Assert.IsTrue(Pulse.HasEnabled != Pulse.IsDisabled);
            Assert.IsTrue(Pulse.HasEnabled != Pulse.HasDisabled);
            Assert.IsTrue(Pulse.HasEnabled != Pulse.IsEnabled);
            Assert.IsTrue(Pulse.HasEnabled == Pulse.HasEnabled);
        }

        [Test]
        public void CannotBeEqualToNull()
        {
            Assert.IsTrue(Pulse.IsDisabled != null);
            Assert.IsTrue(Pulse.HasDisabled != null);
            Assert.IsTrue(Pulse.IsEnabled != null);
            Assert.IsTrue(Pulse.HasEnabled != null);
        }
    }
}

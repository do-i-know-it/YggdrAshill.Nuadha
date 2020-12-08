using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PushToPulse))]
    internal class PushToPulseSpecification
    {
        [Test]
        public void ShouldPulsateWhenHasPushed()
        {
            var pulsation = PushToPulse.HasPushed;

            Assert.IsTrue(pulsation.Pulsate(Push.Disabled, Push.Enabled));

            Assert.IsFalse(pulsation.Pulsate(Push.Enabled, Push.Enabled));
            Assert.IsFalse(pulsation.Pulsate(Push.Enabled, Push.Disabled));
            Assert.IsFalse(pulsation.Pulsate(Push.Disabled, Push.Disabled));
        }

        [Test]
        public void ShouldPulsateWhenIsPushed()
        {
            var pulsation = PushToPulse.IsPushed;

            Assert.IsTrue(pulsation.Pulsate(Push.Enabled, Push.Enabled));

            Assert.IsFalse(pulsation.Pulsate(Push.Disabled, Push.Enabled));
            Assert.IsFalse(pulsation.Pulsate(Push.Enabled, Push.Disabled));
            Assert.IsFalse(pulsation.Pulsate(Push.Disabled, Push.Disabled));
        }

        [Test]
        public void ShouldPulsateWhenHasReleased()
        {
            var pulsation = PushToPulse.HasReleased;

            Assert.IsTrue(pulsation.Pulsate(Push.Enabled, Push.Disabled));

            Assert.IsFalse(pulsation.Pulsate(Push.Disabled, Push.Enabled));
            Assert.IsFalse(pulsation.Pulsate(Push.Enabled, Push.Enabled));
            Assert.IsFalse(pulsation.Pulsate(Push.Disabled, Push.Disabled));
        }

        [Test]
        public void ShouldPulsateWhenIsReleased()
        {
            var pulsation = PushToPulse.IsReleased;

            Assert.IsTrue(pulsation.Pulsate(Push.Disabled, Push.Disabled));

            Assert.IsFalse(pulsation.Pulsate(Push.Disabled, Push.Enabled));
            Assert.IsFalse(pulsation.Pulsate(Push.Enabled, Push.Enabled));
            Assert.IsFalse(pulsation.Pulsate(Push.Enabled, Push.Disabled));
        }
    }
}

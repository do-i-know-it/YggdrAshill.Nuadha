using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TouchToPulse))]
    internal class TouchToPulseSpecification
    {
        [Test]
        public void ShouldPulsateWhenHasTouched()
        {
            var pulsation = TouchToPulse.HasTouched;

            Assert.IsTrue(pulsation.Pulsate(Touch.Disabled, Touch.Enabled));

            Assert.IsFalse(pulsation.Pulsate(Touch.Enabled, Touch.Enabled));
            Assert.IsFalse(pulsation.Pulsate(Touch.Enabled, Touch.Disabled));
            Assert.IsFalse(pulsation.Pulsate(Touch.Disabled, Touch.Disabled));
        }

        [Test]
        public void ShouldPulsateWhenIsTouched()
        {
            var pulsation = TouchToPulse.IsTouched;

            Assert.IsTrue(pulsation.Pulsate(Touch.Enabled, Touch.Enabled));

            Assert.IsFalse(pulsation.Pulsate(Touch.Disabled, Touch.Enabled));
            Assert.IsFalse(pulsation.Pulsate(Touch.Enabled, Touch.Disabled));
            Assert.IsFalse(pulsation.Pulsate(Touch.Disabled, Touch.Disabled));
        }

        [Test]
        public void ShouldPulsateWhenHasReleased()
        {
            var pulsation = TouchToPulse.HasReleased;

            Assert.IsTrue(pulsation.Pulsate(Touch.Enabled, Touch.Disabled));

            Assert.IsFalse(pulsation.Pulsate(Touch.Disabled, Touch.Enabled));
            Assert.IsFalse(pulsation.Pulsate(Touch.Enabled, Touch.Enabled));
            Assert.IsFalse(pulsation.Pulsate(Touch.Disabled, Touch.Disabled));
        }

        [Test]
        public void ShouldPulsateWhenIsReleased()
        {
            var pulsation = TouchToPulse.IsReleased;

            Assert.IsTrue(pulsation.Pulsate(Touch.Disabled, Touch.Disabled));

            Assert.IsFalse(pulsation.Pulsate(Touch.Disabled, Touch.Enabled));
            Assert.IsFalse(pulsation.Pulsate(Touch.Enabled, Touch.Enabled));
            Assert.IsFalse(pulsation.Pulsate(Touch.Enabled, Touch.Disabled));
        }
    }
}

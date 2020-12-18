using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TouchToPulse))]
    internal class TouchToPulseSpecification
    {
        [Test]
        public void ShouldDetectWhenHasTouched()
        {
            var detection = TouchToPulse.HasTouched(Touch.Disabled);

            Assert.IsTrue(detection.Detect(Touch.Enabled));
            Assert.IsFalse(detection.Detect(Touch.Enabled));
            Assert.IsFalse(detection.Detect(Touch.Disabled));
        }

        [Test]
        public void ShouldDetectWhenIsTouched()
        {
            var detection = TouchToPulse.IsTouched(Touch.Disabled);

            Assert.IsTrue(detection.Detect(Touch.Enabled));
            Assert.IsTrue(detection.Detect(Touch.Enabled));
            Assert.IsFalse(detection.Detect(Touch.Disabled));
        }

        [Test]
        public void ShouldDetectWhenHasReleased()
        {
            var detection = TouchToPulse.HasReleased(Touch.Enabled);

            Assert.IsTrue(detection.Detect(Touch.Disabled));
            Assert.IsFalse(detection.Detect(Touch.Disabled));
            Assert.IsFalse(detection.Detect(Touch.Enabled));
        }

        [Test]
        public void ShouldDetectWhenIsReleased()
        {
            var detection = TouchToPulse.IsReleased(Touch.Enabled);

            Assert.IsTrue(detection.Detect(Touch.Disabled));
            Assert.IsTrue(detection.Detect(Touch.Disabled));
            Assert.IsFalse(detection.Detect(Touch.Enabled));
        }
    }
}

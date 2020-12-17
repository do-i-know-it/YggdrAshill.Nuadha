using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PushToPulse))]
    internal class PushToPulseSpecification
    {
        [Test]
        public void ShouldDetectWhenHasPushed()
        {
            var detection = PushToPulse.HasPushed(Push.Disabled);

            Assert.IsTrue(detection.Detect(Push.Enabled));
            Assert.IsFalse(detection.Detect(Push.Enabled));
            Assert.IsFalse(detection.Detect(Push.Disabled));
        }

        [Test]
        public void ShouldDetectWhenIsPushed()
        {
            var detection = PushToPulse.IsPushed(Push.Disabled);

            Assert.IsTrue(detection.Detect(Push.Enabled));
            Assert.IsTrue(detection.Detect(Push.Enabled));
            Assert.IsFalse(detection.Detect(Push.Disabled));
        }

        [Test]
        public void ShouldDetectWhenHasReleased()
        {
            var detection = PushToPulse.HasReleased(Push.Enabled);

            Assert.IsTrue(detection.Detect(Push.Disabled));
            Assert.IsFalse(detection.Detect(Push.Disabled));
            Assert.IsFalse(detection.Detect(Push.Enabled));
        }

        [Test]
        public void ShouldDetectWhenIsReleased()
        {
            var detection = PushToPulse.IsReleased(Push.Enabled);

            Assert.IsTrue(detection.Detect(Push.Disabled));
            Assert.IsTrue(detection.Detect(Push.Disabled));
            Assert.IsFalse(detection.Detect(Push.Enabled));
        }
    }
}

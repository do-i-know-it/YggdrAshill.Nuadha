using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(BlinkToPush))]
    internal class BlinkToPushSpecification
    {
        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldTranslateBlinkToNotPushedWhenRatioIsLowerThanUpperLimitBeforePushed(float upper)
        {
            var threshold = new HysteresisThreshold(upper - 0.1f, upper);
            var translation = new BlinkToPush(threshold);

            var push = translation.Translate(new Blink(upper - 0.1f));

            Assert.AreEqual(Push.Disabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldTranslateBlinkToPushedWhenRatioIsHigherThanUpperLimitBeforePushed(float upper)
        {
            var threshold = new HysteresisThreshold(upper - 0.1f, upper);
            var translation = new BlinkToPush(threshold);

            var push = translation.Translate(new Blink(upper + 0.1f));

            Assert.AreEqual(Push.Enabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldTranslateBlinkToPushedWhenRatioIsHigherThanLowerLimitAfterPushed(float lower)
        {
            var threshold = new HysteresisThreshold(lower, lower + 0.1f);
            var translation = new BlinkToPush(threshold, true);

            var push = translation.Translate(new Blink(lower + 0.1f));

            Assert.AreEqual(Push.Enabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldTranslateBlinkToNotPushedWhenRatioIsLowerThanLowerLimitAfterPushed(float lower)
        {
            var threshold = new HysteresisThreshold(lower, lower + 0.1f);
            var translation = new BlinkToPush(threshold, true);

            var push = translation.Translate(new Blink(lower - 0.1f));

            Assert.AreEqual(Push.Disabled, push);
        }
    }
}

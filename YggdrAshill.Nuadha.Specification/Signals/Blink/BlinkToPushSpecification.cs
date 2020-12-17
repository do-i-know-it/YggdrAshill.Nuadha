using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(BlinkToPush))]
    internal class BlinkToPushSpecification
    {
        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldConvertBlinkToNotPushedWhenRatioIsLowerThanUpperLimitBeforePushed(float upper)
        {
            var threshold = new HysteresisThreshold(upper - 0.1f, upper);
            var conversion = new BlinkToPush(threshold);

            var push = conversion.Convert(new Blink(upper - 0.1f));

            Assert.AreEqual(Push.Disabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldConvertBlinkToPushedWhenRatioIsHigherThanUpperLimitBeforePushed(float upper)
        {
            var threshold = new HysteresisThreshold(upper - 0.1f, upper);
            var conversion = new BlinkToPush(threshold);

            var push = conversion.Convert(new Blink(upper + 0.1f));

            Assert.AreEqual(Push.Enabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldConvertBlinkToPushedWhenRatioIsHigherThanLowerLimitAfterPushed(float lower)
        {
            var threshold = new HysteresisThreshold(lower, lower + 0.1f);
            var conversion = new BlinkToPush(threshold, true);

            var push = conversion.Convert(new Blink(lower + 0.1f));

            Assert.AreEqual(Push.Enabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldConvertBlinkToNotPushedWhenRatioIsLowerThanLowerLimitAfterPushed(float lower)
        {
            var threshold = new HysteresisThreshold(lower, lower + 0.1f);
            var conversion = new BlinkToPush(threshold, true);

            var push = conversion.Convert(new Blink(lower - 0.1f));

            Assert.AreEqual(Push.Disabled, push);
        }
    }
}

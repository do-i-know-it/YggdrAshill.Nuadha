using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PullToPush))]
    internal class PullToPushSpecification
    {
        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldConvertPullToNotPushedWhenStrengthIsLowerThanUpperLimitBeforePushed(float upper)
        {
            var threshold = new HysteresisThreshold(upper - 0.1f, upper);
            var conversion = new PullToPush(threshold);

            var push = conversion.Convert(new Pull(upper - 0.1f));

            Assert.AreEqual(Push.Disabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldConvertPullToPushedWhenStrengthIsHigherThanUpperLimitBeforePushed(float upper)
        {
            var threshold = new HysteresisThreshold(upper - 0.1f, upper);
            var conversion = new PullToPush(threshold);

            var push = conversion.Convert(new Pull(upper + 0.1f));

            Assert.AreEqual(Push.Enabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldConvertPullToPushedWhenStrengthIsHigherThanLowerLimitAfterPushed(float lower)
        {
            var threshold = new HysteresisThreshold(lower, lower + 0.1f);
            var conversion = new PullToPush(threshold, true);

            var push = conversion.Convert(new Pull(lower + 0.1f));

            Assert.AreEqual(Push.Enabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldConvertPullToNotPushedWhenStrengthIsLowerThanLowerLimitAfterPushed(float lower)
        {
            var threshold = new HysteresisThreshold(lower, lower + 0.1f);
            var conversion = new PullToPush(threshold, true);

            var push = conversion.Convert(new Pull(lower - 0.1f));

            Assert.AreEqual(Push.Disabled, push);
        }
    }
}

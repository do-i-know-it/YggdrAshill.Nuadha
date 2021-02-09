using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PullToPush))]
    internal class PullToPushSpecification
    {
        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldTranslatePullToNotPushedWhenStrengthIsLowerThanUpperLimitBeforePushed(float upper)
        {
            var threshold = new HysteresisThreshold(upper - 0.1f, upper);
            var translation = new PullToPush(threshold);

            var push = translation.Translate(new Pull(upper - 0.1f));

            Assert.AreEqual(Push.Disabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldTranslatePullToPushedWhenStrengthIsHigherThanUpperLimitBeforePushed(float upper)
        {
            var threshold = new HysteresisThreshold(upper - 0.1f, upper);
            var translation = new PullToPush(threshold);

            var push = translation.Translate(new Pull(upper + 0.1f));

            Assert.AreEqual(Push.Enabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldTranslatePullToPushedWhenStrengthIsHigherThanLowerLimitAfterPushed(float lower)
        {
            var threshold = new HysteresisThreshold(lower, lower + 0.1f);
            var translation = new PullToPush(threshold, true);

            var push = translation.Translate(new Pull(lower + 0.1f));

            Assert.AreEqual(Push.Enabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldTranslatePullToNotPushedWhenStrengthIsLowerThanLowerLimitAfterPushed(float lower)
        {
            var threshold = new HysteresisThreshold(lower, lower + 0.1f);
            var translation = new PullToPush(threshold, true);

            var push = translation.Translate(new Pull(lower - 0.1f));

            Assert.AreEqual(Push.Disabled, push);
        }
    }
}

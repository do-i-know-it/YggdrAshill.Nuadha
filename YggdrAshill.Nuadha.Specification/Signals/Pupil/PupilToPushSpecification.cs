using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PupilToPush))]
    internal class PupilToPushSpecification
    {
        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldTranslatePupilToNotPushedWhenRatioIsLowerThanUpperLimitBeforePushed(float upper)
        {
            var threshold = new HysteresisThreshold(upper - 0.1f, upper);
            var translation = new PupilToPush(threshold);

            var push = translation.Translate(new Pupil(upper - 0.1f));

            Assert.AreEqual(Push.Disabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldTranslatePupilToPushedWhenRatioIsHigherThanUpperLimitBeforePushed(float upper)
        {
            var threshold = new HysteresisThreshold(upper - 0.1f, upper);
            var translation = new PupilToPush(threshold);

            var push = translation.Translate(new Pupil(upper + 0.1f));

            Assert.AreEqual(Push.Enabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldTranslatePupilToPushedWhenRatioIsHigherThanLowerLimitAfterPushed(float lower)
        {
            var threshold = new HysteresisThreshold(lower, lower + 0.1f);
            var translation = new PupilToPush(threshold, true);

            var push = translation.Translate(new Pupil(lower + 0.1f));

            Assert.AreEqual(Push.Enabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldTranslatePupilToNotPushedWhenRatioIsLowerThanLowerLimitAfterPushed(float lower)
        {
            var threshold = new HysteresisThreshold(lower, lower + 0.1f);
            var translation = new PupilToPush(threshold, true);

            var push = translation.Translate(new Pupil(lower - 0.1f));

            Assert.AreEqual(Push.Disabled, push);
        }
    }
}

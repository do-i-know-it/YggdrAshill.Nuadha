using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PupilToPush))]
    internal class PupilToPushSpecification
    {
        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldConvertPupilToNotPushedWhenRatioIsLowerThanUpperLimitBeforePushed(float upper)
        {
            var threshold = new HysteresisThreshold(upper, upper - 0.1f);
            var conversion = new PupilToPush(threshold);

            var push = conversion.Convert(new Pupil(upper - 0.1f));

            Assert.AreEqual(Push.Disabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldConvertPupilToPushedWhenRatioIsHigherThanUpperLimitBeforePushed(float upper)
        {
            var threshold = new HysteresisThreshold(upper, upper - 0.1f);
            var conversion = new PupilToPush(threshold);

            var push = conversion.Convert(new Pupil(upper + 0.1f));

            Assert.AreEqual(Push.Enabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldConvertPupilToPushedWhenRatioIsHigherThanLowerLimitAfterPushed(float lower)
        {
            var threshold = new HysteresisThreshold(lower + 0.1f, lower);
            var conversion = new PupilToPush(threshold, true);

            var push = conversion.Convert(new Pupil(lower + 0.1f));

            Assert.AreEqual(Push.Enabled, push);
        }

        [TestCase(0.2f)]
        [TestCase(0.1f)]
        public void ShouldConvertPupilToNotPushedWhenRatioIsLowerThanLowerLimitAfterPushed(float lower)
        {
            var threshold = new HysteresisThreshold(lower + 0.1f, lower);
            var conversion = new PupilToPush(threshold, true);

            var push = conversion.Convert(new Pupil(lower - 0.1f));

            Assert.AreEqual(Push.Disabled, push);
        }
    }
}

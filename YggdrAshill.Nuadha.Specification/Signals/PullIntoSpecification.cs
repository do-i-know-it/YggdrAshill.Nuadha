using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PullInto))]
    internal class PullIntoSpecification
    {
        private const float Offset = 0.1f;

        private static Pull Under(float threshold)
        {
            return new Pull(threshold - Offset);
        }

        private static Pull Over(float threshold)
        {
            return new Pull(threshold + Offset);
        }

        [TestCase(0.8f)]
        [TestCase(0.5f)]
        [TestCase(0.2f)]
        public void ShouldConvertPullIntoPush(float threshold)
        {
            var conversion = PullInto.Push(new HysteresisThreshold(threshold));

            Assert.AreEqual(Push.Disabled, conversion.Convert(Under(threshold)));

            Assert.AreEqual(Push.Enabled, conversion.Convert(Over(threshold)));
        }

        [TestCase(0.8f)]
        [TestCase(0.5f)]
        [TestCase(0.2f)]
        public void ShouldConvertPullIntoPulse(float threshold)
        {
            // initial pulse is disabled when pulsation is generated.
            var conversion = PullInto.Pulse(new HysteresisThreshold(threshold));

            // when previous pulse is disabled and detection doesn't detect, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, conversion.Convert(Under(threshold)));

            // when previous pulse is disabled and detection detects, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, conversion.Convert(Over(threshold)));

            // when previous pulse has enabled and detection detects, current pulse is enabled.
            Assert.AreEqual(Pulse.IsEnabled, conversion.Convert(Over(threshold)));

            // when previous pulse is enabled and detection doesn't detect, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, conversion.Convert(Under(threshold)));

            // when previous pulse has disabled and detection doesn't detect, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, conversion.Convert(Under(threshold)));

            // when previous pulse is disabled and detection detects, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, conversion.Convert(Over(threshold)));

            // when previous pulse has enabled and detection doesn't detect, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, conversion.Convert(Under(threshold)));
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = PullInto.Push(default);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = PullInto.Pulse(default);
            });
        }
    }
}

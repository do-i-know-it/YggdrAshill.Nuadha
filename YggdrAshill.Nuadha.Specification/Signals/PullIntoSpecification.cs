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

            Assert.AreEqual(Push.Disabled, conversion.Translate(Under(threshold)));

            Assert.AreEqual(Push.Enabled, conversion.Translate(Over(threshold)));
        }

        [TestCase(0.8f)]
        [TestCase(0.5f)]
        [TestCase(0.2f)]
        public void ShouldConvertPullIntoPulse(float threshold)
        {
            // When condition is generated, initial pulse is disabled.
            var conversion = PullInto.Pulse(new HysteresisThreshold(threshold));

            // When previous pulse is disabled and condition is not satisfied, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, conversion.Translate(Under(threshold)));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, conversion.Translate(Over(threshold)));

            // When previous pulse has enabled and condition is satisfied, current pulse is enabled.
            Assert.AreEqual(Pulse.IsEnabled, conversion.Translate(Over(threshold)));

            // When previous pulse is enabled and condition is not satisfied, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, conversion.Translate(Under(threshold)));

            // When previous pulse has disabled and condition is not satisfied, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, conversion.Translate(Under(threshold)));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, conversion.Translate(Over(threshold)));

            // When previous pulse has enabled and condition is not satisfied, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, conversion.Translate(Under(threshold)));
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

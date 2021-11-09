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
            var translation = PullInto.Push(new HysteresisThreshold(threshold));

            Assert.AreEqual(Push.Disabled, translation.Translate(Under(threshold)));

            Assert.AreEqual(Push.Enabled, translation.Translate(Over(threshold)));
        }

        [TestCase(0.8f)]
        [TestCase(0.5f)]
        [TestCase(0.2f)]
        public void ShouldConvertPullIntoPulse(float threshold)
        {
            // When condition is generated, initial pulse is disabled.
            var translation = PullInto.Pulse(new HysteresisThreshold(threshold));

            // When previous pulse is disabled and condition is not satisfied, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, translation.Translate(Under(threshold)));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, translation.Translate(Over(threshold)));

            // When previous pulse has enabled and condition is satisfied, current pulse is enabled.
            Assert.AreEqual(Pulse.IsEnabled, translation.Translate(Over(threshold)));

            // When previous pulse is enabled and condition is not satisfied, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, translation.Translate(Under(threshold)));

            // When previous pulse has disabled and condition is not satisfied, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, translation.Translate(Under(threshold)));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, translation.Translate(Over(threshold)));

            // When previous pulse has enabled and condition is not satisfied, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, translation.Translate(Under(threshold)));
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = PullInto.Push(default);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = PullInto.Pulse(default);
            });
        }
    }
}

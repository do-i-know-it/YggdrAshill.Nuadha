using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PushInto))]
    internal class PushIntoSpecification
    {
        [Test]
        public void ShouldConvertPushIntoTouch()
        {
            var translation = PushInto.Touch;

            Assert.AreEqual(Touch.Disabled, translation.Translate(Push.Disabled));

            Assert.AreEqual(Touch.Enabled, translation.Translate(Push.Enabled));
        }

        [Test]
        public void ShouldConvertPushIntoPulse()
        {
            // When condition is generated, initial pulse is disabled.
            var translation = PushInto.Pulse;

            // When previous pulse is disabled and condition is not satisfied, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, translation.Translate(Push.Disabled));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, translation.Translate(Push.Enabled));

            // When previous pulse has enabled and condition is satisfied, current pulse is enabled.
            Assert.AreEqual(Pulse.IsEnabled, translation.Translate(Push.Enabled));

            // When previous pulse is enabled and condition is not satisfied, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, translation.Translate(Push.Disabled));

            // When previous pulse has disabled and condition is not satisfied, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, translation.Translate(Push.Disabled));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, translation.Translate(Push.Enabled));

            // When previous pulse has enabled and condition is not satisfied, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, translation.Translate(Push.Disabled));
        }
    }
}

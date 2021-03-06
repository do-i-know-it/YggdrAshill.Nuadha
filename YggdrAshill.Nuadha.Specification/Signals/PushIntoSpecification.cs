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
            var conversion = PushInto.Touch;

            Assert.AreEqual(Touch.Disabled, conversion.Convert(Push.Disabled));

            Assert.AreEqual(Touch.Enabled, conversion.Convert(Push.Enabled));
        }

        [Test]
        public void ShouldConvertPushIntoPulse()
        {
            // When condition is generated, initial pulse is disabled.
            var conversion = PushInto.Pulse;

            // When previous pulse is disabled and condition is not satisfied, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, conversion.Convert(Push.Disabled));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, conversion.Convert(Push.Enabled));

            // When previous pulse has enabled and condition is satisfied, current pulse is enabled.
            Assert.AreEqual(Pulse.IsEnabled, conversion.Convert(Push.Enabled));

            // When previous pulse is enabled and condition is not satisfied, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, conversion.Convert(Push.Disabled));

            // When previous pulse has disabled and condition is not satisfied, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, conversion.Convert(Push.Disabled));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, conversion.Convert(Push.Enabled));

            // When previous pulse has enabled and condition is not satisfied, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, conversion.Convert(Push.Disabled));
        }
    }
}

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
            // initial pulse is disabled when pulsation is generated.
            var conversion = PushInto.Pulse;

            // when previous pulse is disabled and detection doesn't detect, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, conversion.Convert(Push.Disabled));

            // when previous pulse is disabled and detection detects, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, conversion.Convert(Push.Enabled));

            // when previous pulse has enabled and detection detects, current pulse is enabled.
            Assert.AreEqual(Pulse.IsEnabled, conversion.Convert(Push.Enabled));

            // when previous pulse is enabled and detection doesn't detect, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, conversion.Convert(Push.Disabled));

            // when previous pulse has disabled and detection doesn't detect, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, conversion.Convert(Push.Disabled));

            // when previous pulse is disabled and detection detects, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, conversion.Convert(Push.Enabled));

            // when previous pulse has enabled and detection doesn't detect, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, conversion.Convert(Push.Disabled));
        }
    }
}

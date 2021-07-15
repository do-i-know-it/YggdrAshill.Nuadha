using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TouchInto))]
    internal class TouchIntoSpecification
    {
        [Test]
        public void ShouldConvertTouchIntoPush()
        {
            var conversion = TouchInto.Push;

            Assert.AreEqual(Push.Disabled, conversion.Convert(Touch.Disabled));

            Assert.AreEqual(Push.Enabled, conversion.Convert(Touch.Enabled));
        }

        [Test]
        public void ShouldConvertTouchIntoPulse()
        {
            // initial pulse is disabled when pulsation is generated.
            var conversion = TouchInto.Pulse;

            // when previous pulse is disabled and detection doesn't detect, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, conversion.Convert(Touch.Disabled));

            // when previous pulse is disabled and detection detects, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, conversion.Convert(Touch.Enabled));

            // when previous pulse has enabled and detection detects, current pulse is enabled.
            Assert.AreEqual(Pulse.IsEnabled, conversion.Convert(Touch.Enabled));

            // when previous pulse is enabled and detection doesn't detect, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, conversion.Convert(Touch.Disabled));

            // when previous pulse has disabled and detection doesn't detect, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, conversion.Convert(Touch.Disabled));

            // when previous pulse is disabled and detection detects, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, conversion.Convert(Touch.Enabled));

            // when previous pulse has enabled and detection doesn't detect, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, conversion.Convert(Touch.Disabled));
        }
    }
}

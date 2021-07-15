using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TouchIs))]
    internal class TouchIsSpecification
    {
        [Test]
        public void ShouldDetectWhenTouchIsDisabled()
        {
            Assert.IsTrue(TouchIs.Disabled.Detect(Touch.Disabled));
            Assert.IsFalse(TouchIs.Disabled.Detect(Touch.Enabled));
        }

        [Test]
        public void ShouldDetectWhenTouchIsEnabled()
        {
            Assert.IsFalse(TouchIs.Enabled.Detect(Touch.Disabled));
            Assert.IsTrue(TouchIs.Enabled.Detect(Touch.Enabled));
        }
    }
}

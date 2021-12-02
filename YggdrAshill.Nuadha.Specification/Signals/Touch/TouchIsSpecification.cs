using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TouchIs))]
    internal class TouchIsSpecification
    {
        [Test]
        public void ShouldBeSatisfiedWhenTouchIsDisabled()
        {
            Assert.IsTrue(TouchIs.Disabled.Notify(Touch.Disabled));
            Assert.IsFalse(TouchIs.Disabled.Notify(Touch.Enabled));
        }

        [Test]
        public void ShouldBeSatisfiedWhenTouchIsEnabled()
        {
            Assert.IsFalse(TouchIs.Enabled.Notify(Touch.Disabled));
            Assert.IsTrue(TouchIs.Enabled.Notify(Touch.Enabled));
        }
    }
}

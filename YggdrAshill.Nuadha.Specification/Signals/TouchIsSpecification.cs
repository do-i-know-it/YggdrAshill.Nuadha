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
            Assert.IsTrue(TouchIs.Disabled.IsSatisfiedBy(Touch.Disabled));
            Assert.IsFalse(TouchIs.Disabled.IsSatisfiedBy(Touch.Enabled));
        }

        [Test]
        public void ShouldBeSatisfiedWhenTouchIsEnabled()
        {
            Assert.IsFalse(TouchIs.Enabled.IsSatisfiedBy(Touch.Disabled));
            Assert.IsTrue(TouchIs.Enabled.IsSatisfiedBy(Touch.Enabled));
        }
    }
}

using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(WhenTouchIs))]
    internal class WhenTouchIsSpecification
    {
        [Test]
        public void ShouldNotifyWhenIsEnabled()
        {
            Assert.IsTrue(WhenTouchIs.Enabled.Notify(Touch.Enabled));
            Assert.IsFalse(WhenTouchIs.Enabled.Notify(Touch.Disabled));
        }

        [Test]
        public void ShouldNotifyWhenIsDisabled()
        {
            Assert.IsFalse(WhenTouchIs.Disabled.Notify(Touch.Enabled));
            Assert.IsTrue(WhenTouchIs.Disabled.Notify(Touch.Disabled));
        }

        [Test]
        public void ShouldNotifyWhenOneIsEqualToAnother()
        {
            Assert.IsTrue(WhenTouchIs.EqualTo.Evaluate(Touch.Disabled, Touch.Disabled));
            Assert.IsFalse(WhenTouchIs.EqualTo.Evaluate(Touch.Disabled, Touch.Enabled));
            Assert.IsFalse(WhenTouchIs.EqualTo.Evaluate(Touch.Enabled, Touch.Disabled));
            Assert.IsTrue(WhenTouchIs.EqualTo.Evaluate(Touch.Enabled, Touch.Enabled));
        }

        [Test]
        public void ShouldNotifyWhenOneIsNotEqualToAnother()
        {
            Assert.IsFalse(WhenTouchIs.NotEqualTo.Evaluate(Touch.Disabled, Touch.Disabled));
            Assert.IsTrue(WhenTouchIs.NotEqualTo.Evaluate(Touch.Disabled, Touch.Enabled));
            Assert.IsTrue(WhenTouchIs.NotEqualTo.Evaluate(Touch.Enabled, Touch.Disabled));
            Assert.IsFalse(WhenTouchIs.NotEqualTo.Evaluate(Touch.Enabled, Touch.Enabled));
        }
    }
}

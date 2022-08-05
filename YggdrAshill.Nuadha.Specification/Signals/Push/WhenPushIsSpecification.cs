using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(WhenPushIs))]
    internal class WhenPushIsSpecification
    {
        [Test]
        public void ShouldNotifyWhenIsEnabled()
        {
            Assert.IsTrue(WhenPushIs.Enabled.Notify(Push.Enabled));
            Assert.IsFalse(WhenPushIs.Enabled.Notify(Push.Disabled));
        }

        [Test]
        public void ShouldNotifyWhenIsDisabled()
        {
            Assert.IsFalse(WhenPushIs.Disabled.Notify(Push.Enabled));
            Assert.IsTrue(WhenPushIs.Disabled.Notify(Push.Disabled));
        }

        [Test]
        public void ShouldNotifyWhenOneIsEqualToAnother()
        {
            Assert.IsTrue(WhenPushIs.EqualTo.Evaluate(Push.Disabled, Push.Disabled));
            Assert.IsFalse(WhenPushIs.EqualTo.Evaluate(Push.Disabled, Push.Enabled));
            Assert.IsFalse(WhenPushIs.EqualTo.Evaluate(Push.Enabled, Push.Disabled));
            Assert.IsTrue(WhenPushIs.EqualTo.Evaluate(Push.Enabled, Push.Enabled));
        }

        [Test]
        public void ShouldNotifyWhenOneIsNotEqualToAnother()
        {
            Assert.IsFalse(WhenPushIs.NotEqualTo.Evaluate(Push.Disabled, Push.Disabled));
            Assert.IsTrue(WhenPushIs.NotEqualTo.Evaluate(Push.Disabled, Push.Enabled));
            Assert.IsTrue(WhenPushIs.NotEqualTo.Evaluate(Push.Enabled, Push.Disabled));
            Assert.IsFalse(WhenPushIs.NotEqualTo.Evaluate(Push.Enabled, Push.Enabled));
        }
    }
}

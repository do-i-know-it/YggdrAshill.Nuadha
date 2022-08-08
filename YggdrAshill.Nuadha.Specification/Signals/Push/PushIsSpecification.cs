using NUnit.Framework;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PushIs))]
    internal class PushIsSpecification
    {
        [Test]
        public void ShouldDetectSignalWhenIsEnabled()
        {
            Assert.IsTrue(PushIs.Enabled.Detect(Push.Enabled));
            Assert.IsFalse(PushIs.Enabled.Detect(Push.Disabled));
        }

        [Test]
        public void ShouldDetectSignalWhenIsDisabled()
        {
            Assert.IsFalse(PushIs.Disabled.Detect(Push.Enabled));
            Assert.IsTrue(PushIs.Disabled.Detect(Push.Disabled));
        }

        [Test]
        public void ShouldDetectSignalWhenOneIsEqualToAnother()
        {
            Assert.IsTrue(PushIs.EqualTo.Detect(new Analysis<Push>(Push.Disabled, Push.Disabled)));
            Assert.IsFalse(PushIs.EqualTo.Detect(new Analysis<Push>(Push.Disabled, Push.Enabled)));
            Assert.IsFalse(PushIs.EqualTo.Detect(new Analysis<Push>(Push.Enabled, Push.Disabled)));
            Assert.IsTrue(PushIs.EqualTo.Detect(new Analysis<Push>(Push.Enabled, Push.Enabled)));
        }

        [Test]
        public void ShouldDetectSignalWhenOneIsNotEqualToAnother()
        {
            Assert.IsFalse(PushIs.NotEqualTo.Detect(new Analysis<Push>(Push.Disabled, Push.Disabled)));
            Assert.IsTrue(PushIs.NotEqualTo.Detect(new Analysis<Push>(Push.Disabled, Push.Enabled)));
            Assert.IsTrue(PushIs.NotEqualTo.Detect(new Analysis<Push>(Push.Enabled, Push.Disabled)));
            Assert.IsFalse(PushIs.NotEqualTo.Detect(new Analysis<Push>(Push.Enabled, Push.Enabled)));
        }
    }
}

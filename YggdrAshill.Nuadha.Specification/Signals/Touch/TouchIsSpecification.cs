using NUnit.Framework;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TouchIs))]
    internal class TouchIsSpecification
    {
        [Test]
        public void ShouldDetectSignalWhenIsEnabled()
        {
            Assert.IsTrue(TouchIs.Enabled.Detect(Touch.Enabled));
            Assert.IsFalse(TouchIs.Enabled.Detect(Touch.Disabled));
        }

        [Test]
        public void ShouldDetectSignalWhenIsDisabled()
        {
            Assert.IsFalse(TouchIs.Disabled.Detect(Touch.Enabled));
            Assert.IsTrue(TouchIs.Disabled.Detect(Touch.Disabled));
        }

        [Test]
        public void ShouldDetectSignalWhenOneIsEqualToAnother()
        {
            Assert.IsTrue(TouchIs.EqualTo.Detect(new Analysis<Touch>(Touch.Disabled, Touch.Disabled)));
            Assert.IsFalse(TouchIs.EqualTo.Detect(new Analysis<Touch>(Touch.Disabled, Touch.Enabled)));
            Assert.IsFalse(TouchIs.EqualTo.Detect(new Analysis<Touch>(Touch.Enabled, Touch.Disabled)));
            Assert.IsTrue(TouchIs.EqualTo.Detect(new Analysis<Touch>(Touch.Enabled, Touch.Enabled)));
        }

        [Test]
        public void ShouldDetectSignalWhenOneIsNotEqualToAnother()
        {
            Assert.IsFalse(TouchIs.NotEqualTo.Detect(new Analysis<Touch>(Touch.Disabled, Touch.Disabled)));
            Assert.IsTrue(TouchIs.NotEqualTo.Detect(new Analysis<Touch>(Touch.Disabled, Touch.Enabled)));
            Assert.IsTrue(TouchIs.NotEqualTo.Detect(new Analysis<Touch>(Touch.Enabled, Touch.Disabled)));
            Assert.IsFalse(TouchIs.NotEqualTo.Detect(new Analysis<Touch>(Touch.Enabled, Touch.Enabled)));
        }
    }
}

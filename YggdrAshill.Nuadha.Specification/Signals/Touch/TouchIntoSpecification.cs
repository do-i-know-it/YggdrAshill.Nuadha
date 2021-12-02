using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TouchInto))]
    internal class TouchIntoSpecification
    {
        [Test]
        public void ShouldConvertTouchIntoPush()
        {
            var translation = TouchInto.Push;

            Assert.AreEqual(Push.Disabled, translation.Translate(Touch.Disabled));

            Assert.AreEqual(Push.Enabled, translation.Translate(Touch.Enabled));
        }

        [Test]
        public void ShouldConvertTouchIntoPull()
        {
            var translation = TouchInto.Pull;

            Assert.AreEqual(new Pull(Pull.Minimum), translation.Translate(Touch.Disabled));

            Assert.AreEqual(new Pull(Pull.Maximum), translation.Translate(Touch.Enabled));
        }
    }
}

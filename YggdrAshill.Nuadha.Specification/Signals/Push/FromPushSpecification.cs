using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(FromPush))]
    internal class FromPushSpecification
    {
        [TestCase(true)]
        [TestCase(false)]
        public void ShouldConvertPushIntoTouch(bool expected)
        {
            Assert.AreEqual((Touch)expected, FromPush.IntoTouch.Translate((Push)expected));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldConvertPushIntoPull(bool expected)
        {
            Assert.AreEqual((Pull)expected, FromPush.IntoPull.Translate((Push)expected));
        }
    }
}

using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(WhenPullIs))]
    internal class WhenPullIsSpecification
    {
        [TestCase(0.9f, 0.8f, 1.0f)]
        [TestCase(0.8f, 0.7f, 0.9f)]
        [TestCase(0.7f, 0.6f, 0.8f)]
        [TestCase(0.6f, 0.5f, 0.7f)]
        [TestCase(0.5f, 0.4f, 0.6f)]
        [TestCase(0.4f, 0.3f, 0.5f)]
        [TestCase(0.3f, 0.2f, 0.4f)]
        [TestCase(0.2f, 0.1f, 0.3f)]
        [TestCase(0.1f, 0.0f, 0.2f)]
        public void ShouldNotifyWhenOneIsOverAnother(float expected, float under, float over)
        {
            Assert.IsTrue(WhenPullIs.Over.Evaluate((Pull)over, (Pull)expected));
            Assert.IsTrue(WhenPullIs.Over.Evaluate((Pull)expected, (Pull)expected));
            Assert.IsFalse(WhenPullIs.Over.Evaluate((Pull)under, (Pull)expected));
        }

        [TestCase(0.9f, 0.8f, 1.0f)]
        [TestCase(0.8f, 0.7f, 0.9f)]
        [TestCase(0.7f, 0.6f, 0.8f)]
        [TestCase(0.6f, 0.5f, 0.7f)]
        [TestCase(0.5f, 0.4f, 0.6f)]
        [TestCase(0.4f, 0.3f, 0.5f)]
        [TestCase(0.3f, 0.2f, 0.4f)]
        [TestCase(0.2f, 0.1f, 0.3f)]
        [TestCase(0.1f, 0.0f, 0.2f)]
        public void ShouldNotifyWhenOneIsUnderAnother(float expected, float under, float over)
        {
            Assert.IsFalse(WhenPullIs.Under.Evaluate((Pull)over, (Pull)expected));
            Assert.IsTrue(WhenPullIs.Under.Evaluate((Pull)expected, (Pull)expected));
            Assert.IsTrue(WhenPullIs.Under.Evaluate((Pull)under, (Pull)expected));
        }
    }
}

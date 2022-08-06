using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
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
            Assert.IsTrue(WhenPullIs.Over.Notify(new Analysis<Pull>((Pull)expected, (Pull)over)));
            Assert.IsTrue(WhenPullIs.Over.Notify(new Analysis<Pull>((Pull)expected, (Pull)expected)));
            Assert.IsFalse(WhenPullIs.Over.Notify(new Analysis<Pull>((Pull)expected, (Pull)under)));
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
            Assert.IsFalse(WhenPullIs.Under.Notify(new Analysis<Pull>((Pull)expected, (Pull)over)));
            Assert.IsTrue(WhenPullIs.Under.Notify(new Analysis<Pull>((Pull)expected, (Pull)expected)));
            Assert.IsTrue(WhenPullIs.Under.Notify(new Analysis<Pull>((Pull)expected, (Pull)under)));
        }
    }
}

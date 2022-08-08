using NUnit.Framework;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PullIs))]
    internal class PullIsSpecification
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
        public void ShouldDetectSignalWhenOneIsEqualToAnother(float expected, float under, float over)
        {
            Assert.IsFalse(PullIs.EqualTo.Detect(new Analysis<Pull>((Pull)expected, (Pull)over)));
            Assert.IsTrue(PullIs.EqualTo.Detect(new Analysis<Pull>((Pull)expected, (Pull)expected)));
            Assert.IsFalse(PullIs.EqualTo.Detect(new Analysis<Pull>((Pull)expected, (Pull)under)));
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
        public void ShouldDetectSignalWhenOneIsNotEqualToAnother(float expected, float under, float over)
        {
            Assert.IsTrue(PullIs.NotEqualTo.Detect(new Analysis<Pull>((Pull)expected, (Pull)over)));
            Assert.IsFalse(PullIs.NotEqualTo.Detect(new Analysis<Pull>((Pull)expected, (Pull)expected)));
            Assert.IsTrue(PullIs.NotEqualTo.Detect(new Analysis<Pull>((Pull)expected, (Pull)under)));
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
        public void ShouldDetectSignalWhenOneIsMoreThanAnother(float expected, float under, float over)
        {
            Assert.IsTrue(PullIs.MoreThan.Detect(new Analysis<Pull>((Pull)expected, (Pull)over)));
            Assert.IsFalse(PullIs.MoreThan.Detect(new Analysis<Pull>((Pull)expected, (Pull)expected)));
            Assert.IsFalse(PullIs.MoreThan.Detect(new Analysis<Pull>((Pull)expected, (Pull)under)));
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
        public void ShouldDetectSignalWhenOneIsLessThanAnother(float expected, float under, float over)
        {
            Assert.IsFalse(PullIs.LessThan.Detect(new Analysis<Pull>((Pull)expected, (Pull)over)));
            Assert.IsFalse(PullIs.LessThan.Detect(new Analysis<Pull>((Pull)expected, (Pull)expected)));
            Assert.IsTrue(PullIs.LessThan.Detect(new Analysis<Pull>((Pull)expected, (Pull)under)));
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
        public void ShouldDetectSignalWhenOneIsOverAnother(float expected, float under, float over)
        {
            Assert.IsTrue(PullIs.Over.Detect(new Analysis<Pull>((Pull)expected, (Pull)over)));
            Assert.IsTrue(PullIs.Over.Detect(new Analysis<Pull>((Pull)expected, (Pull)expected)));
            Assert.IsFalse(PullIs.Over.Detect(new Analysis<Pull>((Pull)expected, (Pull)under)));
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
        public void ShouldDetectSignalWhenOneIsUnderAnother(float expected, float under, float over)
        {
            Assert.IsFalse(PullIs.Under.Detect(new Analysis<Pull>((Pull)expected, (Pull)over)));
            Assert.IsTrue(PullIs.Under.Detect(new Analysis<Pull>((Pull)expected, (Pull)expected)));
            Assert.IsTrue(PullIs.Under.Detect(new Analysis<Pull>((Pull)expected, (Pull)under)));
        }
    }
}

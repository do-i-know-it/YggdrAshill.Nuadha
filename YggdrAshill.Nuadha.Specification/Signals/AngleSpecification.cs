using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Angle))]
    internal class AngleSpecification
    {
        [TestCase(-180.0f)]
        [TestCase(180.0f)]
        [TestCase(0.0f)]
        public void ShouldSignifyDegree(float expected)
        {
            Assert.AreEqual(expected, new Angle(expected).Degree);
        }

        [Test]
        public void CannotBeGeneratedWithNaN()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Angle(float.NaN);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNumberLowerThanNegative180()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Angle(-180.1f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNumberHigherThanPositive180()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Angle(180.1f);
            });
        }
    }
}

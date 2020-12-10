using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Pupil))]
    internal class PupilSpecification
    {
        [TestCase(1.0f)]
        [TestCase(0.5f)]
        [TestCase(0.0f)]
        public void ShouldSignifyRatio(float expected)
        {
            Assert.AreEqual(expected, new Pupil(expected).Ratio);
        }

        [Test]
        public void CannotBeGeneratedWithNaN()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Pupil(float.NaN);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNumberLowerThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Pupil(-0.1f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNumberHigherThanOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Pupil(1.1f);
            });
        }
    }
}
